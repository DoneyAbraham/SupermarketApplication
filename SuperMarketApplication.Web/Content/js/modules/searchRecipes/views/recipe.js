var template = require("../templates/recipe.html"),
    SuperMarketTemplate = require("../templates/superMarket.html"),
    SuperMarketMapModalTemplate = require("../templates/superMarketMapModal.html"),
    SuperMarketsCollection = require("../collections/superMarkets.js");

module.exports = Backbone.View.extend({

    tagName: "article",
    className: "container",
    template: _.template(template),
    superMarketTemplate: _.template(SuperMarketTemplate),
    superMarketMapModalTemplate: _.template(SuperMarketMapModalTemplate),

    events: {
        "mouseover": "mouseover",
        "mouseout": "mouseout",
        "click .btn-add-to-cart": "addToCart"
    },

    initialize: function () {
        this.listenTo(App, "ingredients", this.distinguishIngredients)
            .listenTo(App, "card:clear", this.resetCartButtons)
            .listenTo(this, "distinguishedIngredients", this.findSuperMarkets);

        this.render();
    },

    render: function () {
        this.$el.html(this.template(this.model.toJSON()));
        this.superMarketsList = this.$(".super-markets-list");

        App.trigger("recipe:mouseover", this.model);
    },

    mouseover: function (e) {
        return;
        if (e.target !== this.el && !this.el.contains(e.target) || $(e.target).is(".btn-missing-ingredients")) {
            return;
        }
        
        App.trigger("recipe:mouseover", this.model);
    },

    mouseout: function (e) {
        if (this.el.contains(e.toElement) || $(e.target).is(".btn-missing-ingredients")) {
            return;
        }

        App.trigger("recipe:mouseout");
    },

    distinguishIngredients: function (ingredients) {
        var missingIngredients = [];

        this.$(".ingredients-list li").each(function () {
            var li = $(this),
                text = $.trim(li.text());

            _.each(ingredients, function (ingredient) {
                ingredient = $.trim(ingredient);
                if ((text.indexOf(ingredient) > -1) || (ingredient.indexOf(text)) > -1) {
                    li.addClass("in-containers");
                } else {
                    li.addClass("not-in-containers");
                }
            });
        });

        missingIngredients = this.$(".ingredients-list li.not-in-containers").map(function () { return $(this).text(); }).get();

        this.trigger("distinguishedIngredients", missingIngredients);
    },

    findSuperMarkets: function (ingredients) {
        this.superMarkets = new SuperMarketsCollection();
        this.missingIngredients = ingredients;

        this.superMarkets.findByIngredients(ingredients);

        this.listenTo(this.superMarkets, "sync", this.renderSuperMarkets);
    },

    renderSuperMarkets: function () {
        this.superMarketsList.empty();
        this.superMarkets.each(this.renderSuperMarket, this);

        if (this.superMarkets.length) {
            this.superMarketsList.parent().removeClass("hide");
        }
    },

    renderSuperMarket: function (superMarket) {
        var id = _.uniqueId("map-modal"),
            li, showMapButton, modal, canvas,
            geo = new google.maps.Geocoder(),
            mapOptions = {
                zoom: 15
            },
            map;

        superMarket.setTotalPrice(this.missingIngredients);
        li = $(this.superMarketTemplate(superMarket.toJSON()));
        showMapButton = li.find(".btn-show-map");

        li.find(".btn-missing-ingredients").popover({
            placement: "left",
            trigger: "hover",
            html: true
        });

        modal = $(this.superMarketMapModalTemplate(superMarket.toJSON())).appendTo(document.body);
        modal.attr("id", id);
        showMapButton.attr("data-target", "#" + id);
        canvas = modal.find(".modal-body");

        modal.on("shown.bs.modal", function () {
            geo.geocode({ address: superMarket.get("Address") }, function (results) {
                if (!results || !results.length) {
                    return;
                }

                mapOptions.center = results[0].geometry.location;
                map = new google.maps.Map(canvas[0], mapOptions);

                new google.maps.Marker({
                    position: mapOptions.center,
                    map: map,
                    title: superMarket.get("Name")
                });
            });
        });

        this.superMarketsList.append(li);
    },

    addToCart: function(e) {
        var btn = $(e.currentTarget),
            superMarket = this.superMarkets.get(btn.data("supermarket-id")),
            ingredients = _.pluck(superMarket.getIngredients(this.missingIngredients), "Id"),
            icon = btn.find("i"),
            alternate = icon.data("alternate");

        icon.data("alternate", icon.attr("class"));
        icon.attr("class", alternate);
        btn.toggleClass("btn-danger");

        App.trigger("cart:add", {
            recipeName: this.model.get("recipeName"),
            superMarketId: superMarket.id,
            ingredients: ingredients,
            totalPrice: superMarket.get("TotalPrice")
        });
    },

    resetCartButtons: function() {
        this.$(".btn-add-to-cart").removeClass("btn-danger").find("i").attr("class", "glyphicon glyphicon-shopping-cart");
    },

    remove: function () {
        if (this.superMarkets) {
            this.superMarkets.cancelSearch();
        }

        Backbone.View.prototype.remove.call(this);
    }

});