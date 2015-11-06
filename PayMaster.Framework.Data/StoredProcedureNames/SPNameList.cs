namespace PayMaster.Framework.Data.StoredProcedureNames
{
    public static class SpNameList
    {
        //Login Module
        public static string UspUserLogin = "[dbo].[USPUserLogin]";

        //OpCode Module
        public static string UspGetOpCodeList = "[dbo].[USPGetOpCodeList]";
        public static string UspInsertOrUpdate = "[dbo].[UspInsertOrUpdate]";

        public static string UspGetMessage = "[dbo].[USPGetMessage]";

        //User Module
        public static string UspGetUser = "[dbo].[USPGetUser]";
        public static string UspAddEditUser = "[dbo].[USPAddEditUser]";
        public static string UspDeleteUser = "[dbo].[USPDeleteUser]";

        //Role
        public static string UspGetRole = "[dbo].[USPGetRole]";
        public static string UspAddEditRole = "[dbo].[USPAddEditRole]";
        public static string UspDeleteRole = "[dbo].[USPDeleteRole]";

        //Payee
        public static string UspGetPayee = "[dbo].[USPGetPayee]";
        public static string UspAddOrUpdate = "[dbo].[USPAddEditPayee]";
        public static string UspDeletePayee = "[dbo].[USPDeletePayee]";
        public static string UspGetPayeeType = "[dbo].[USPGetPayeeType]";

        //UserRoleMap Module 
        public static string UspGetUserRole = "[dbo].[USPGetUserRole]";
        public static string UspAddEditUserRole = "[dbo].[USPAddEditUserRoleMap]";
        public static string UspDeleteUserRole = "[dbo].[USPDeleteUserRoleMap]";
        public static string UspGetAllUserName = "[dbo].[UspGetAllUser_Role]";
       
        //Address Module
        public static string UspGetAddress = "[dbo].[USPGetAddress]";
        public static string UspAddEditAddress = "[dbo].[USPAddEditAddress]";
        public static string UspDeleteAddress = "[dbo].[USPDeleteAddress]"; // no need


        //PayeeAdrdessMap    
        public static string UspGetPayeeAddressList = "[dbo].[USPGetPayeeAddressList]";      
        public static string UspDeletePayeeAddressMapping = "[dbo].[USPDeletePayeeAddressMapping]";
        public static string UspAddEditPayeeAddressMapping = "[dbo].[USPAddEditPayeeAddressMapping]";
        public static string UspGetPayeeDetailsForMap = "[dbo].[USPGetPayeeDetailsForMap]";
        public static string UspGetAddressDetailsForPayeeAddressMap = "[dbo].[USPGetAddressDetailsForPayeeAddressMap]";
        public static string UspcrudPayeeAddressMapping = "[dbo].USPCRUDPayeeAddressMapping";

        //BankAccount
        public static string UspGetBankAccountList = "[dbo].[USPGetBankAccountList]";
        public static string UspInsertOrUpdateBankAccount = "[dbo].[USPInsertOrUpdateBankAccount]";
        public static string UspGetPayeeBankAccountMap = "[dbo].[USPGetPayeeBankAccountMap]";
        public static string UspGetPayeeBankAccountMapAud = "[dbo].[USPGetPayeeBankAccountMap_AUD]";

        //Partner
        public static string UspGetPartner = "[dbo].[UspGetPartner]";
        public static string UspGetPartnerByOpCodeId = "[dbo].[USPGetPartnerByOpCodeId]";

        //Log

        public static string USPGetLogDetails = "[dbo].[USPGetLogDetails]";

    }
}