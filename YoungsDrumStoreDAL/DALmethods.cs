using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using YoungsDrumStoreDAL.Models;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace YoungsDrumStoreDAL
{
    public class DALmethods
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        protected DataMapper dataMapper = new DataMapper();

        public void CreateAccount(AccountDO account)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandCreateAccount = new SqlCommand("sp_CreateAccount", sqlConnection);
            try
            {
                commandCreateAccount.CommandType = CommandType.StoredProcedure;
                commandCreateAccount.Parameters.AddWithValue("@RoleID", account.RoleId = 3);
                commandCreateAccount.Parameters.AddWithValue("@UserName", account.UserName);
                commandCreateAccount.Parameters.AddWithValue("@PassWord", account.PassWord);
                commandCreateAccount.Parameters.AddWithValue("@FirstName", account.FirstName);
                commandCreateAccount.Parameters.AddWithValue("@LastName", account.LastName);
                commandCreateAccount.Parameters.AddWithValue("@Email", account.Email);

                sqlConnection.Open();
                commandCreateAccount.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Create Account", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }//end of Create Account

        public List<AccountDO> ViewAllAccounts()
        {
            List<AccountDO> accountList = new List<AccountDO>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandViewAccounts = new SqlCommand("sp_ViewAllAccounts", sqlConnection);
            DataTable accountTable = new DataTable();
            try
            {
                commandViewAccounts.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(commandViewAccounts))
                {
                    dataAdapter.Fill(accountTable);
                }
                accountList = dataMapper.MapAccountTableToList(accountTable);
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("View Accounts", DateTime.Now, sqlEx.Message);

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return accountList;
        }//end of view accounts

        public void UpdateAccountAdmin(AccountDO accountDO)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandUpdateAccount = new SqlCommand("sp_UpdateAccount", sqlConnection);
            try
            {
                commandUpdateAccount.CommandType = CommandType.StoredProcedure;
                commandUpdateAccount.Parameters.AddWithValue("@AccountID", accountDO.AccountID);
                commandUpdateAccount.Parameters.AddWithValue("@RoleID", accountDO.RoleId);
                commandUpdateAccount.Parameters.AddWithValue("@PassWord", accountDO.PassWord);
                commandUpdateAccount.Parameters.AddWithValue("@UserName", accountDO.UserName);
                commandUpdateAccount.Parameters.AddWithValue("@FirstName", accountDO.FirstName);
                commandUpdateAccount.Parameters.AddWithValue("@LastName", accountDO.LastName);

                sqlConnection.Open();
                commandUpdateAccount.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {

                DataErrorLogger.ErrorLogger("Update Account(Admin)", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }//end of update account

        public void DeleteAccount(int AccountID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandDeleteAccount = new SqlCommand("sp_DeleteAccount", sqlConnection);
            try
            {
                commandDeleteAccount.CommandType = CommandType.StoredProcedure;
                commandDeleteAccount.Parameters.AddWithValue("@AccountID", AccountID);

                sqlConnection.Open();
                commandDeleteAccount.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {

                DataErrorLogger.ErrorLogger("Delete Account", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }//end of delete account

        public AccountDO GetAccountInfoByID(int AccountID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandGetInfoByID = new SqlCommand("sp_GetAccountInfoByID", sqlConnection);
            AccountDO accountDO = new AccountDO();

            try
            {
                commandGetInfoByID.CommandType = CommandType.StoredProcedure;
                commandGetInfoByID.Parameters.AddWithValue("@AccountID", AccountID);
                sqlConnection.Open();
                using (SqlDataReader reader = commandGetInfoByID.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accountDO.UserName = (string)reader["UserName"];
                        accountDO.FirstName = (string)reader["FirstName"];
                        accountDO.LastName = (string)reader["LastName"];
                        accountDO.Email = (string)reader["Email"];
                    }
                }
            }
            catch (SqlException sqlEx)
            {

                DataErrorLogger.ErrorLogger("Get account info by ID", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return accountDO;
        }//end of get account info by ID

        public AccountDO GetAccountInfoByUserName(string UserName)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandGetByUserName = new SqlCommand("sp_GetAccountInfoByUserName",sqlConnection);
            AccountDO accountDO = new AccountDO();
            try
            {
                commandGetByUserName.CommandType = CommandType.StoredProcedure;
                commandGetByUserName.Parameters.AddWithValue("@UserName", UserName);
                sqlConnection.Open();
                using (SqlDataReader reader = commandGetByUserName.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accountDO.AccountID = Convert.ToInt32(reader["AccountID"]);
                        accountDO.RoleId = (int)reader["RoleID"];
                        accountDO.PassWord = (string)reader["PassWord"];
                        accountDO.FirstName = (string)reader["FirstName"];
                        accountDO.LastName = (string)reader["LastName"];
                        accountDO.Email = (string)reader["Email"];
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Get account info by UserName", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return accountDO;
        }


        //-----------------------METHODS FOR DRUMS-------------------------

        public void CreateDrum(DrumDO drumDO)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandCreateDrum = new SqlCommand("sp_AddDrum", sqlConnection);
            try
            {
                commandCreateDrum.CommandType = CommandType.StoredProcedure;
                commandCreateDrum.Parameters.AddWithValue("@AccountID", drumDO.AccountID);
                commandCreateDrum.Parameters.AddWithValue("@BrandName", drumDO.BrandName);
                commandCreateDrum.Parameters.AddWithValue("@DrumType", drumDO.DrumType);
                commandCreateDrum.Parameters.AddWithValue("@DrumDescription", drumDO.DrumDescription);
                commandCreateDrum.Parameters.AddWithValue("@DrumQuantity", drumDO.DrumQuantity);
                commandCreateDrum.Parameters.AddWithValue("@DrumPrice", drumDO.DrumPrice);
                commandCreateDrum.Parameters.AddWithValue("@DrumImgURL", drumDO.DrumImgURL);

                sqlConnection.Open();
                commandCreateDrum.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Create Drum", DateTime.Now, sqlEx.Message);

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public List<DrumDO> ViewAllDrums()
        {
            List<DrumDO> drumList = new List<DrumDO>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandViewAllDrums = new SqlCommand("sp_ViewAllDrums", sqlConnection);
            DataTable drumTable = new DataTable();
            try
            {
                commandViewAllDrums.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(commandViewAllDrums))
                {
                    dataAdapter.Fill(drumTable);
                }
                drumList = dataMapper.MapDrumTableToList(drumTable);
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("View Drums", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return drumList;
        }

        public void UpdateDrum(DrumDO drumDO)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandUpdateDrum = new SqlCommand("sp_UpdateDrumInfo", sqlConnection);
            try
            {
                commandUpdateDrum.CommandType = CommandType.StoredProcedure;
                commandUpdateDrum.Parameters.AddWithValue("@DrumID", drumDO.DrumID);
                commandUpdateDrum.Parameters.AddWithValue("@BrandName", drumDO.BrandName);
                commandUpdateDrum.Parameters.AddWithValue("@DrumType", drumDO.DrumType);
                commandUpdateDrum.Parameters.AddWithValue("@DrumDescription", drumDO.DrumDescription);
                commandUpdateDrum.Parameters.AddWithValue("@DrumQuantity", drumDO.DrumQuantity);
                commandUpdateDrum.Parameters.AddWithValue("@DrumPrice", drumDO.DrumPrice);
                commandUpdateDrum.Parameters.AddWithValue("@DrumImgURL", drumDO.DrumImgURL);

                sqlConnection.Open();
                commandUpdateDrum.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Update Drum", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public void DeleteDrum(int DrumID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandDeleteDrum = new SqlCommand("sp_DeleteDrum", sqlConnection);
            try
            {
                commandDeleteDrum.CommandType = CommandType.StoredProcedure;
                commandDeleteDrum.Parameters.AddWithValue("@DrumID", DrumID);

                sqlConnection.Open();
                commandDeleteDrum.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Delete Drum", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public DrumDO GetDrumInfoByID(int DrumID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandGetDrumInfoByID = new SqlCommand("sp_GetDrumInfoByID", sqlConnection);
            DrumDO drumDO = new DrumDO();
            try
            {
                commandGetDrumInfoByID.CommandType = CommandType.StoredProcedure;
                commandGetDrumInfoByID.Parameters.AddWithValue("@DrumID", DrumID);
                sqlConnection.Open();
                using (SqlDataReader reader = commandGetDrumInfoByID.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        drumDO.AccountID = Convert.ToInt32(reader["AccountID"]);
                        drumDO.DrumID = Convert.ToInt32(reader["DrumID"]);
                        drumDO.BrandName = (string)reader["BrandName"];
                        drumDO.DrumType = (string)reader["DrumType"];
                        drumDO.DrumDescription = (string)reader["DrumDescription"];
                        drumDO.DrumPrice = (decimal)reader["DrumPrice"];
                        drumDO.DrumQuantity = (int)reader["DrumQuantity"];
                        drumDO.DrumImgURL = (string)reader["DrumImgURL"];
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Get Drum info by ID", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return drumDO;
        }

        public void UpdateDrumQuantity(int drumID, int checkoutQty)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandUpdateQty = new SqlCommand("sp_UpdateDrumQuantity",sqlConnection);
            try
            {
                commandUpdateQty.CommandType = CommandType.StoredProcedure;
                commandUpdateQty.Parameters.AddWithValue("@DrumID", drumID);
                commandUpdateQty.Parameters.AddWithValue("@CheckoutQuantity", checkoutQty);

                sqlConnection.Open();
                commandUpdateQty.ExecuteNonQuery();
            }
            catch(SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("UpdateQty", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }


        //------------------------------METHODS FOR CYMBAL OBJECT----------------------------------

        public void CreateCymbal(CymbalDO cymbalDO)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandCreateCymbal = new SqlCommand("sp_AddCymbal", sqlConnection);
            try
            {
                commandCreateCymbal.CommandType = CommandType.StoredProcedure;
                commandCreateCymbal.Parameters.AddWithValue("@AccountID", cymbalDO.AccountID);
                commandCreateCymbal.Parameters.AddWithValue("@BrandName", cymbalDO.BrandName);
                commandCreateCymbal.Parameters.AddWithValue("@CymbalName", cymbalDO.CymbalName);
                commandCreateCymbal.Parameters.AddWithValue("@CymbalDescription", cymbalDO.CymbalDescription);
                commandCreateCymbal.Parameters.AddWithValue("@CymbalPrice", cymbalDO.CymbalPrice);
                commandCreateCymbal.Parameters.AddWithValue("@CymbalQuantity", cymbalDO.CymbalQuantity);
                commandCreateCymbal.Parameters.AddWithValue("@CymbalImgURL", cymbalDO.CymbalImgURL);

                sqlConnection.Open();
                commandCreateCymbal.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Create Cymbal", DateTime.Now, sqlEx.Message);

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public List<CymbalDO> ViewAllCymbals()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandViewAllCymbals = new SqlCommand("sp_ViewAllCymbals", sqlConnection);
            List<CymbalDO> cymbalList = new List<CymbalDO>();
            DataTable cymbalTable = new DataTable();
            try
            {
                commandViewAllCymbals.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(commandViewAllCymbals))
                {
                    dataAdapter.Fill(cymbalTable);
                }
                cymbalList = dataMapper.MapDCymbalTableToList(cymbalTable);
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("View All Cymbals", DateTime.Now, sqlEx.Message);

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return cymbalList;
        }

        public void UpdateCymbal(CymbalDO cymbalDO)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandUpdateCymbal = new SqlCommand("sp_UpdateCymbalInfo", sqlConnection);
            try
            {
                commandUpdateCymbal.CommandType = CommandType.StoredProcedure;
                commandUpdateCymbal.Parameters.AddWithValue("@CymbalID", cymbalDO.CymbalID);
                commandUpdateCymbal.Parameters.AddWithValue("@BrandName", cymbalDO.BrandName);
                commandUpdateCymbal.Parameters.AddWithValue("@CymbalName", cymbalDO.CymbalName);
                commandUpdateCymbal.Parameters.AddWithValue("@CymbalDescription", cymbalDO.CymbalDescription);
                commandUpdateCymbal.Parameters.AddWithValue("@CymbalPrice", cymbalDO.CymbalPrice);
                commandUpdateCymbal.Parameters.AddWithValue("@CymbalQuantity", cymbalDO.CymbalQuantity);
                commandUpdateCymbal.Parameters.AddWithValue("@CymbalImgURL", cymbalDO.CymbalImgURL);

                sqlConnection.Open();
                commandUpdateCymbal.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Update Cymbal", DateTime.Now, sqlEx.Message);

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public void DeleteCymbal(int cymbalID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandDeleteCymbal = new SqlCommand("sp_DeleteCymbal", sqlConnection);
            try
            {
                commandDeleteCymbal.CommandType = CommandType.StoredProcedure;
                commandDeleteCymbal.Parameters.AddWithValue("@CymbalID", cymbalID);

                sqlConnection.Open();
                commandDeleteCymbal.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Delete Cymbal", DateTime.Now, sqlEx.Message);

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public CymbalDO GetCymbalInfoByID(int cymbalID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandGetCymbalInfo = new SqlCommand("sp_GetCymbalInfoByID", sqlConnection);
            CymbalDO cymbalDO = new CymbalDO();
            try
            {
                commandGetCymbalInfo.CommandType = CommandType.StoredProcedure;
                commandGetCymbalInfo.Parameters.AddWithValue("@CymbalID", cymbalID);

                sqlConnection.Open();
                using (SqlDataReader reader = commandGetCymbalInfo.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        cymbalDO.AccountID = Convert.ToInt32(reader["AccountID"]);
                        cymbalDO.CymbalID = Convert.ToInt32(reader["CymbalID"]);
                        cymbalDO.BrandName = (string)reader["BrandName"];
                        cymbalDO.CymbalName = (string)reader["CymbalName"];
                        cymbalDO.CymbalDescription = (string)reader["CymbalDescription"];
                        cymbalDO.CymbalPrice = (decimal)reader["CymbalPrice"];
                        cymbalDO.CymbalQuantity = Convert.ToInt32(reader["CymbalQuantity"]);
                        cymbalDO.CymbalImgURL = (string)reader["CymbalImgURL"];
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("Get Cymbal info by ID", DateTime.Now, sqlEx.Message);

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return cymbalDO;
        }

        public void UpdateCymbalQty(int cymbalID, int checkoutQty)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand commandUpdateCymbalQty = new SqlCommand("sp_UpdateCymbalQuantity", sqlConnection);
            try
            {
                commandUpdateCymbalQty.CommandType = CommandType.StoredProcedure;
                commandUpdateCymbalQty.Parameters.AddWithValue("@CymbalID", cymbalID);
                commandUpdateCymbalQty.Parameters.AddWithValue("@CheckoutQuantity", checkoutQty);

                sqlConnection.Open();
                commandUpdateCymbalQty.ExecuteNonQuery();
            }
            catch(SqlException sqlEx)
            {
                DataErrorLogger.ErrorLogger("UpdateCymbalQty", DateTime.Now, sqlEx.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

    }//end of class DAL methods
}
