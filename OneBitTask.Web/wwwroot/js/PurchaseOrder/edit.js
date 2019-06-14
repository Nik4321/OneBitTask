var PurchaseOrderEdit = (function () {

    var purchaseOrderPriceInput = null;
    var purchaseOrderQuantityInput = null;
    var purchaseOrderTotalAmountInput = null;

    function init() {
        selectElements();
        attachEventHandlers();
    }

    function selectElements() {
        purchaseOrderPriceInput = $('#purchase-order-price-input');
        purchaseOrderQuantityInput = $('#purchase-order-quantity-input');
        purchaseOrderTotalAmountInput = $('#purchase-order-total-amount-input');
    }

    function attachEventHandlers() {
        purchaseOrderPriceInput.on('keyup', purchaseOrderSumTotalAmount);
        purchaseOrderQuantityInput.on('keyup', purchaseOrderSumTotalAmount);
    }

    function purchaseOrderSumTotalAmount() {
        var price = parseFloat(purchaseOrderPriceInput.val());
        var quantity = parseFloat(purchaseOrderQuantityInput.val());

        if (isNaN(price) || isNaN(quantity)) {
            purchaseOrderTotalAmountInput.val("Invalid Quantity or Price");
            return;
        }

        var totalAmount = roundNumber((price * quantity), 2);
        purchaseOrderTotalAmountInput.val(totalAmount);
    }

    function roundNumber(num, dec) {
        var result = Math.round(num * Math.pow(10, dec)) / Math.pow(10, dec);
        return result;
    }

    return {
        init: init
    };
})();