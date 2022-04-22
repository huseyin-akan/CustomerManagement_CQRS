using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class Messages
    {
        public static string TodoAdded = "Todo has been added successfully";
        public static string TodoNotFound = "Todo with that id can not be found!!";
        public static string TodoUpdateFailed = "Todo can not be updated. Something is wrong!!";

        public static string ModelNotFound = "Model can not be found!!!";

        public static string UserNotFound = "User is not found";
        public static string PasswordError = "Password is wrong. Try again!!";

        public static string IndividualCustomerDoesntExist = "No Individual customer with that id exists!!";
        public static string CorporateCustomerDoesntExist = "No Corporate customer with that id exists!!";
        public static string FindexScoreNotEnough = "Findex score is not enough to rent the car!!";
        public static string NationalIdAlreadyUsed = "This national id was used before!!";
        public static string TaxNumberAlreadyUsed = "This tax number was used before!!";
        public static string UsernameAlreadyTaken = "This username was taken already. Please choose another username!!";
        public static string EmailAlreadyTaken = "This email was taken already. If you forgot your password, try to reset it";
    }
}
