1.给用户test1，配置权限 xxx。
如何记录该变化?

清空数据
truncate table [handycontext_test].[dbo].hy_auth_role_hy_user;
truncate table [handycontext_test].[dbo].[HistoryFieldValue];
delete [handycontext_test].[dbo].[HistoryField];
delete [handycontext_test].[dbo].[LogEvent];
--delete [handycontext_test].[dbo].[LogEventType];
delete [handycontext_test].[dbo].HistoryTable;
delete dbo.hy_auth_role;
delete dbo.hy_user;

EF学习
http://www.cnblogs.com/shanyou/archive/2011/07/17/2108953.html
EF问题集
http://www.cnblogs.com/mecity/archive/2011/07/08/2099853.html