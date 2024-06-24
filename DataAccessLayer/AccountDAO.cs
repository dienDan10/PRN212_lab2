using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class AccountDAO
    {

        public static AccountMember GetAccountById(string accountID)
        {
            MyStoreContext context = new MyStoreContext();
            AccountMember account = null;
            try
            {
             account = context.AccountMembers.FirstOrDefault(acc => acc.MemberId.Equals(accountID));
                Console.WriteLine(account.FullName);   
            } catch (Exception e) { 
                Console.WriteLine(e.Message);
            }
           
            return account;
        }
    }
}
