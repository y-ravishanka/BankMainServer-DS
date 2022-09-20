using Microsoft.Data;
using Microsoft.Data.SqlClient;
using BankMainServer1.Data;
using System.Data;

namespace BankMainServer1.Model
{
    internal class Database
    {
        private readonly SqlConnection con = new(@"Data Source=DESKTOP-1G3ODQ5;Initial Catalog=bankmain;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private int i = 0, j = 0;
        private string que = null;

        internal bool testCon()
        {
            bool test = false;
            que = "select 1";
            SqlCommand cmd = new(que, con);
            try 
            { 
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                    test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            {
                con.Close();
            }
            GC.Collect();
            return test;
        }

        #region Activity Log Section
        internal bool setActivityLog(int id)
        {
            bool t = false;
            que = "exec insert_logintime @id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
                t = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal bool setLogoutTime(int id)
        {
            bool t = false;
            que = "exec insert_logouttime @id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                t = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                t = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal List<ActivityLog> GetActivityLogs(int id, int value)
        {
            List<ActivityLog> list = new();
            ActivityLog log;
            if (id == 0)
            {
                que = "select id,logintime,logouttime from activitylog";
            }
            else if (id == 1)
            {
                que = "select id,logintime,logouttime from activitylog where id = " + value;
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        log = new ActivityLog();
                        log.id = dr.GetInt32(0).ToString();
                        log.login = dr.GetSqlDateTime(1).ToString();
                        log.logout = dr.GetSqlDateTime(2).ToString();
                        list.Add(log);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }
        #endregion

        #region Branch Section
        internal string GetBranchURL(int id)
        {
            string url = null;
            que = "select baseurl from branchbaseurl where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        url = dr.GetString(0);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return url;
        }

        internal void ChangeBranchURL(int id, string url)
        {
            que = "update branchbaseurl set baseurl = '" + url + "' where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
        }

        internal void InsertBranchURL(int id, string url)
        {
            que = "insert into branchbaseurl values() where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
        }

        internal Branch GetBranches_byID(int id)
        {
            Branch log = new();
            que = "select id,town,saddress,city,distric,province,zip,phone1,phone2,email,managerid from branch where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32("id");
                        log.name = dr.GetString("town");
                        log.saddress = dr.GetString("saddress");
                        log.city = dr.GetString("city");
                        log.distric = dr.GetString("distric");
                        log.province = dr.GetString("province");
                        log.zip = dr.GetString("zip");
                        log.phone1 = dr.GetString("phone1");
                        log.phone2 = dr.GetString("phone2");
                        log.email = dr.GetString("email");
                        log.managerid = dr.GetInt32("managerid");
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        internal List<Branch> GetBranches(int id, string value)
        {
            List<Branch> list = new();
            Branch log;
            switch (id)
            {
                case 0:
                    que = "select id,town,saddress,city,distric,province,zip,phone1,phone2,email,managerid from branch";
                    break;
                case 1:
                    que = "select id,town,saddress,city,distric,province,zip,phone1,phone2,email,managerid from branch where city = '" + value + "'";
                    break;
                case 2:
                    que = "select id,town,saddress,city,distric,province,zip,phone1,phone2,email,managerid from branch where distric = '" + value + "'";
                    break;
                case 3:
                    que = "select id,town,saddress,city,distric,province,zip,phone1,phone2,email,managerid from branch where province = '" + value + "'";
                    break;
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log = new Branch();
                        log.id = dr.GetInt32("id");
                        log.name = dr.GetString("town");
                        log.saddress = dr.GetString("saddress");
                        log.city = dr.GetString("city");
                        log.distric = dr.GetString("distric");
                        log.province = dr.GetString("province");
                        log.zip = dr.GetString("zip");
                        log.phone1 = dr.GetString("phone1");
                        log.phone2 = dr.GetString("phone2");
                        log.email = dr.GetString("email");
                        log.managerid = dr.GetInt32("managerid"); 
                        list.Add(log);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }
        #endregion

        #region Login Details Section
        internal ClientLogin GetLogin(string nic)
        {
            ClientLogin login = new();
            que = "select id,nic,password,posision,active from login_details where nic ='" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        login.id = dr.GetInt32("id"); 
                        login.nic = dr.GetString("nic");
                        login.password = dr.GetString("password");
                        login.posision = dr.GetString("posision");
                        login.active = dr.GetString("active");
                    }
                }
                dr.Close();
            }
            catch(Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return login;
        }

        internal bool UpdateLogin(UpdateValue update)
        {
            bool id = false;
            que = "update login_details set " + update.field + " = '" + update.value + "' where nic = '" + update.nav + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                id = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                id = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return id;
        }
        #endregion

        internal bool UpdateStatus(UpdateValue update)
        {
            bool id = false;
            que = "update fullstatus set " + update.field + " = '" + update.value + "' where date = '" + update.nav + "'";
            SqlCommand cmd = new(que, con);
            try
            { 
                con.Open();
                cmd.ExecuteNonQuery();
                id = true;
            }
            catch (Exception e)
            {
                Console.WriteLine (e.Message);
                id = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return id;
        }

        internal FullStatus GetStatus(string date)
        {
            FullStatus status = new();
            que = "select date,deposits,damount,withdraws,wamount,balance,newaccounts from fullstatus where date = '" + date + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        status.date = dr.GetString("date");
                        status.deposits = dr.GetInt32("deposits");
                        status.damount = dr.GetFloat("damount");
                        status.withdraws = dr.GetInt32("withdraws");
                        status.wamount = dr.GetFloat("wamount");
                        status.balance = dr.GetFloat("balance");
                        status.newaccounts = dr.GetInt32("newaccount");
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return status;
        }

        internal List<FullStatus> GetStatus_list()
        {
            List<FullStatus> list = new();
            FullStatus status;
            que = "select date,deposits,damount,withdraws,wamount,balance,newaccounts from fullstatus";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        status = new FullStatus
                        {
                            date = dr.GetString("date"),
                            deposits = dr.GetInt32("deposits"),
                            damount = dr.GetFloat("damount"),
                            withdraws = dr.GetInt32("withdraws"),
                            wamount = dr.GetFloat("wamount"),
                            balance = dr.GetFloat("balance"),
                            newaccounts = dr.GetInt32("newaccount")
                        };
                        list.Add(status);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal List<Employee> GetEmployees(int id, int value)
        {
            List<Employee> list = new();
            Employee log;
            if(id == 0)
            {
                que = "select id,nic,fname, lname,dob,saddress,city,sidtric,province,zip,phone1,phone2,email,branchid from employee";
            }
            else if(id == 1)
            {
                que = "select id,nic,fname, lname,dob,saddress,city,sidtric,province,zip,phone1,phone2,email,branchid from employee where branchid = " + value;
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log = new Employee
                        {
                            id = dr.GetInt32("id"),
                            nic = dr.GetString("nic"),
                            fname = dr.GetString("fname"),
                            lname = dr.GetString("lname"),
                            dob = dr.GetString("dob"),
                            saddress = dr.GetString("saddress"),
                            city = dr.GetString("city"),
                            distric = dr.GetString("distric"),
                            province = dr.GetString("province"),
                            zip = dr.GetString("zip"),
                            phone1 = dr.GetString("phone1"),
                            phone2 = dr.GetString("phone2"),
                            email = dr.GetString("email"),
                            branch = dr.GetInt32("branchid")
                        };
                        list.Add(log);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal Employee GetEmployees_byNumber(int nav, string number)
        {
            Employee log = new();
            if(nav == 0)
            {
                que = "select id,nic,fname, lname,dob,saddress,city,sidtric,province,zip,phone1,phone2,email,branchid from employee where nic = '" + number + "'";
            }
            else if(nav == 1)
            {
                que = "select id,nic,fname, lname,dob,saddress,city,sidtric,province,zip,phone1,phone2,email,branchid from employee where id = '" + number + "'";
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32("id");
                        log.nic = dr.GetString("nic");
                        log.fname = dr.GetString("fname");
                        log.lname = dr.GetString("lname");
                        log.dob = dr.GetString("dob");
                        log.saddress = dr.GetString("saddress");
                        log.city = dr.GetString("city");
                        log.distric = dr.GetString("distric");
                        log.province = dr.GetString("province");
                        log.zip = dr.GetString("zip");
                        log.phone1 = dr.GetString("phone1");
                        log.phone2 = dr.GetString("phone2");
                        log.email = dr.GetString("email");
                        log.branch = dr.GetInt32("branchid");
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        internal bool UpdateEmployee(UpdateValue update)
        {
            bool id = false;
            que = "update employee set " + update.field + " = '" + update.value + "' where nic = '" + update.nav + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                id = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                id = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return id;
        }

        internal Account GetAccount_byNymber(int number)
        {
            Account acc = new();
            que = "select number,nic,balance,active,branchid,createby from account where number = " + number;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while (dr.Read())
                    {
                        acc.number = dr.GetInt32(0);
                        acc.nic = dr.GetString(1);
                        acc.balance = dr.GetDouble(2);
                        acc.active = dr.GetString(3);
                        acc.branchid = dr.GetInt32(4);
                        acc.createby = dr.GetInt32(5);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return acc;
        }

        internal List<Account> GetAccounts(int id, string str)
        {
            List<Account> list = new();
            Account acc;
            switch(id)
            {
                case 1:
                    que = "select number,nic,balance,active,branchid,createby from account where nic = '" + str + "'";
                    break;
                case 2:
                    que = "select number,nic,balance,active,branchid,createby from account where active = '" + str + "'";
                    break;
                case 3:
                    que = "select number,nic,balance,active,branchid,createby from account where branchid = '" + str + "'";
                    break;
                case 4:
                    que = "select number,nic,balance,active,branchid,createby from account where createby = '" + str + "'";
                    break;
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        acc = new Account();
                        acc.number = dr.GetInt32(0);
                        acc.nic = dr.GetString(1);
                        acc.balance = dr.GetDouble(2);
                        acc.active = dr.GetString(3);
                        acc.branchid = dr.GetInt32(4);
                        acc.createby = dr.GetInt32(5);
                        list.Add(acc);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }
    }
}
