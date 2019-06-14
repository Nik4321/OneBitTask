namespace OneBitTask.ViewModels.PurchaseOrder
{
    public class BasePurchaseOrderViewModel
    {
        protected const int MINIMUM_DESCRIPTION = 3;
        protected const int MAXIMUM_DESCRIPTION = 50;

        protected const int MINIMUM_QUANTITY = 1;
        protected const int MAXIMUM_QUANTITY = 100;

        protected const double MINIMUM_Price = 1;
        protected const double MAXIMUM_Price = 9999999999999999.99;
    }
}