# gym-management-web

##健身房管理網站
1. DB MSSQL LOCALDB
2. WEB Asp .NET Core 8,jQuery, bootstrap
3. 架構
	- 網站
	- APP
	- WEB API

4. 網站 
	- 資料建檔
		- 會員(Member)
		- 方案(Product)
		- 付款方式(PayType)
		- 方案類別(ProductType)
		- 方案(Product)
	- 管理
		- 商店管理
		- 會員進出場管理

5. WEB API
	- 註冊
	- 登入
	- 購買
	- 開啟票券
	- 顯示場內人數

6. DB Tables
	- Member(會員基本資料)
	- MemberCheckIn(會員入出場紀錄)
	- MemberProduct(會員方案)
	- OnlineProduct(線上商店方案)
	- PayType(付款方式)
	- Product(方案基本資料)
	- ProductType(方案類型)