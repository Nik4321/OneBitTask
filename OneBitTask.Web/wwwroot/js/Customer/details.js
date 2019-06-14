var CustomerDetails = (function () {

    var deletePurchaseOrderBtn = null;
    var changePurchaseOrderStatusBtn = null;

    var purchaseOrderPriceInput = null;
    var purchaseOrderQuantityInput = null;
    var purchaseOrderTotalAmountInput = null;

    function init() {
        selectElements();
        attachEventHandlers();
    }

    function selectElements() {
        deletePurchaseOrderBtn = $('.delete-purchase-order-btn');
        changePurchaseOrderStatusBtn = $('.change-purchase-order-status-btn');
        purchaseOrderPriceInput = $('#purchase-order-price-input');
        purchaseOrderQuantityInput = $('#purchase-order-quantity-input');
        purchaseOrderTotalAmountInput = $('#purchase-order-total-amount-input');
    }

    function attachEventHandlers() {
        deletePurchaseOrderBtn.on('click', removePurchaseOrder);
        changePurchaseOrderStatusBtn.on('click', changePurchaseOrderStatus);
        purchaseOrderPriceInput.on('keyup', purchaseOrderSumTotalAmount);
        purchaseOrderQuantityInput.on('keyup', purchaseOrderSumTotalAmount);
    }

    function removePurchaseOrder(event) {
        var id = event.target.id;
        $.ajax({
            url: '/purchaseOrder/delete',
            type: 'DELETE',
            data: {
                id: id
            },
            success: function (res) {
                toastr.success(res);
                setTimeout(function () {
                    location.reload();
                }, 700);
            }
        });
    }

    function changePurchaseOrderStatus(event) {
        var id = event.target.id;
        $.ajax({
            url: '/purchaseOrder/changeStatus',
            type: 'PUT',
            data: {
                id: id
            },
            success: function (res) {
                toastr.success(res);
                setTimeout(function () {
                    location.reload();
                }, 700);
            }
        });
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