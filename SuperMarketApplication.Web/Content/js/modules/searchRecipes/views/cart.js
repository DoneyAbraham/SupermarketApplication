var CheckoutModalTemplate = require("../templates/checkoutModal.html"),
    CheckoutSuccessModalTemplate = require("../templates/checkoutSuccessModal.html");
module.exports = Backbone.View.extend({

    el: "#recipe-search-container .shopping-cart",
    items: [],

    modalTemplate: _.template(CheckoutModalTemplate),
    successModalTemplate: _.template(CheckoutSuccessModalTemplate),

    events: {
        "click": "showCheckoutModal"
    },

    initialize: function () {
        this.items = [];
        this.listenTo(App, "cart:add", this.add);

        this.$el.popover({
            trigger: "hover",
            html: true,
            placement: "bottom",
            container: document.body,
            title: _.bind(this.renderPopoverTitle, this),
            content: _.bind(this.renderPopoverContent, this)
        });

        this.successModal = $(this.successModalTemplate());
    },

    add: function (item) {
        var existing = _.findWhere(this.items, { superMarketId: item.superMarketId, recipeName: item.recipeName });
        
        if (existing) {
            return this.removeItem(existing);
        }

        this.items.push(item);
        this.$el.addClass("show");
    },

    removeItem: function(item) {
        this.items = _.without(this.items, item);

        if (!this.items.length) {
            this.$el.removeClass("show");
        }
    },

    showCheckoutModal: function(e) {
        var self = this,
            modal = $(this.modalTemplate()),
            totalPrice = this.getTotalPrice();

        modal.find(".items").html("<h3>Recipes</h3>" + this.renderPopoverContent()).append("<hr />").append("<p><strong>Total: Kr. " + totalPrice + "</strong></p>");

        modal.on("hidden.bs.modal", function () {
            modal.remove();
        }).on("shown.bs.modal", function () {
            modal.find("input").first().focus();
        }).on("submit", "form", _.bind(this.placeOrder, this));

        _.each(App.history.last().toJSON(), function (value, key) {
            modal.find("#" + key).val(value);
        });

        modal.modal("show");

        this.modal = modal;
    },

    placeOrder: function (e) {
        var self = this,
            btn = this.modal.find(".btn-place-order"),
            data = { UserId: userId, TotalPrice: this.getTotalPrice() };

        this.modal.find("input").each(function () {
            data[this.id] = this.value;
        });

        data.Recipes = _.pluck(this.items, "recipeName");
        data.Ingredients = _.flatten(_.map(this.items, function (item) {
            return item.ingredients;
        }));

        btn.button("loading");

        $.ajax({
            url: "/api/supermarkets",
            method: "post",
            dataType: "json",
            data: data,
            complete: function (response) {
                self.modal.modal("hide");
                self.clear();
                self.successModal.modal("show");
                
                App.trigger("card:order", response.responseJSON);
            }
        });

        e.preventDefault();
    },

    clear: function() {
        this.items = [];
        this.$el.removeClass("show");
        App.trigger("card:clear");
    },

    renderPopoverTitle: function(el) {
        var totalPrice = this.getTotalPrice();
        return "Shopping cart: (" + totalPrice + ")";
    },

    renderPopoverContent: function (el) {
        return _.map(this.items, function (item) {
            return "<p>" + item.recipeName + " (" + item.totalPrice + ")</p>";
        }).join("");
    },

    getTotalPrice: function () {
        var totalPrice = _.reduce(this.items, function (memo, item) { return memo + item.totalPrice }, 0);
        return (Math.round(totalPrice * 100) / 100);
    }

});