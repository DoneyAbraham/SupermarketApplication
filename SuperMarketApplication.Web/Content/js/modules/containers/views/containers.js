var ContainerView = require("./container.js");

module.exports = Backbone.View.extend({

    el: "#containers-list",

    initialize: function () {
        this.listenTo(this.collection, "add", this.add);

        return this.render();
    },

    render: function () {
        this.collection.each(this.add, this);

        return this;
    },

    add: function (model) {
        var view = new ContainerView({ model: model });

        this.$el.append(view.el);
    }

});