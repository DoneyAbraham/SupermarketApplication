var HistoryCollection = require("../../user/collections/history.js"),
    HistoryTemplate = require("../templates/history.html");

module.exports = Backbone.View.extend({

    el: "#history-list",

    template: _.template(HistoryTemplate),

    initialize: function () {
        this.collection = new HistoryCollection();

        this.listenTo(this.collection, "add", this.add);

        this.collection.listenTo(App, "card:order", this.collection.add);

        this.collection.fetch();

        App.history = this.collection;

        return this.render();
    },

    render: function () {

        return this;
    },

    add: function (model) {
        var section = $(this.template(model.toJSON()));

        section.prependTo(this.$el);
    }

});