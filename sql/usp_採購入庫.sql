ALTER PROCEDURE [dbo].[usp_採購入庫]
	@採購訂單ID INT
AS
BEGIN
	/* 不回傳受影響的筆數 */
	SET NOCOUNT ON;

	/* 看採購訂單是否存在? */
	IF NOT EXISTS
	(
		SELECT 1
		FROM dbo.採購訂單
		WHERE 採購訂單ID = @採購訂單ID
	)
	BEGIN
		/* 丟回 '錯誤編號, 錯誤訊息, 狀態' */
		;THROW 50001, N'找不到指定的採購訂單', 1;
	END;

	/* 防止同一張採購單重複入庫 */
	IF EXISTS
	(
		SELECT 1
		FROM dbo.採購訂單
		WHERE 採購訂單ID = @採購訂單ID 
			AND 狀態 <> N'待入庫'
	)
	BEGIN
		;THROW 50002,  N'此採購訂單不是待入庫狀態', 1;
	END;

	BEGIN TRY
		BEGIN TRAN;
		/* 更新存貨 */
		UPDATE I
		SET I.數量 = I.數量 + PD.數量
		FROM dbo.存貨 AS I
		INNER JOIN dbo.採購訂單明細 AS PD
			ON I.物料ID = PD.物料ID
		WHERE PD.採購訂單ID = @採購訂單ID;

		/* 新增庫存異動 */
		INSERT INTO dbo.庫存異動
		(
			倉庫ID,
			物料ID,
			異動類型,
			數量,
			參考編號
		)
		SELECT
			I.倉庫ID,
			PD.物料ID,
			N'採購入庫',
			PD.數量,
			P.採購訂單編號
		FROM dbo.採購訂單明細 AS PD
		INNER JOIN dbo.採購訂單 AS P
			ON PD.採購訂單ID = P.採購訂單ID
		INNER JOIN dbo.存貨 AS I
			ON I.物料ID = PD.物料ID
		WHERE PD.採購訂單ID = @採購訂單ID;

		/* 採購訂單改成已入庫 */
		UPDATE dbo.採購訂單
		SET 狀態 = N'已入庫'
		WHERE 採購訂單ID = @採購訂單ID;

		COMMIT TRAN;
	END TRY

	BEGIN CATCH

	 IF @@TRANCOUNT > 0
		ROLLBACK TRAN;
	/* 把剛才抓到的原始錯誤重新丟出去 */
	 THROW;

	END CATCH;

END;