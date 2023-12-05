namespace SofiForce.Sync.Common.PromotionModels
{
    public class PromotionError
    {
        public static string INVALID_MODEL = "Invalid order please enter all data and try again";
        public static string INVALID_ITEMS = "Invalid order, order cannot be empty please enter all data and try again";

        public static string INVALID_CLIENT = "Invalid Client please select client and try again";
        public static string INACTVE_CLIENT = "The select client is inactive , select another one and try again";
        public static string INACTVE_REP = "The Sales Man. is inactive , select another one and try again";


        public static string INVALID_QOUTA = "Client has exceed his qouta for {0} , please try again";
        public static string INVALID_CREDIT = "Client has exceed his credit limit , please try again";
        public static string INVALID_LIMIT = "Client has exceed his Sales Limit ({0}) for this month , please try again";

        public static string INVALID_ORDER_TOTAL = "The Order total should be greater than {0} , please try again";
        public static string INVALID_ITEM = "The Item {0} has been blocked , please try again";
        public static string INVALID_BATCH = "The Batch {0} in item {1}  has been blocked , please try again";
        public static string INVALID_BATCH_QTY = "No quantity available for Product {0} you request {1} and available {2} , please try again";
        public static string INVALID_BOUNS_QTY = "No bouns quantity available for Product {0} you request {1} and available {2} , please try again";

        public static string INVALID_BATCH_FOUND = "NO available batch For Product {0}, please try again";

        public static string INACTVE_BRANCH = "The branch {0} is blocked , please try again";
        public static string INACTVE_WAREHOUSE = "The Warehouse {0} is blocked , please try again";
        public static string ITEM_EXPIRED = "The Item {0} is expired , please try again";

        public static string INVALID_TOTAL = "Invalid Invoice Total , please try again";

        public static string ERROR_VALIDATION = "Error in validation , please try again";
        public static string ERROR_PROMOTION = "Error in prmotion , please try again";
        public static string ERROR_CALCULATION = "Error in calculation , please try again";

    }
}
