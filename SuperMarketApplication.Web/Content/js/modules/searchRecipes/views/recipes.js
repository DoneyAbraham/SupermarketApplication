var RecipeView = require("./recipe.js");

module.exports = Backbone.View.extend({

    el: "#recipe-results",

    initialize: function () {
        this.views = [];
        this.listenTo(this.collection, "add", this.add)
            .listenTo(this.collection, "reset", this.reset)
            .listenTo(this.collection, "search:begin", this.showLoader)
            .listenTo(this.collection, "search:end", this.hideLoader);
    },

    render: function () {

    },

    add: function (model) {
        var view = new RecipeView({ model: model });

        view.$el.appendTo(this.$el);

        this.views.push(view);
    },

    reset: function () {
        _.invoke(this.views, "remove");
    },

    showLoader: function () {
        $(".loader").addClass("show");
    },

    hideLoader: function () {
        $(".loader").removeClass("show");
    }

});