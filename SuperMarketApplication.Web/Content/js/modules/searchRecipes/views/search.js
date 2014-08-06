module.exports = Backbone.View.extend({
    
    el: "#recipe-search-container",

    events: {
        "keyup .recipe-search-input": "search"
    },

    initialize: function () {
        this.collection.listenTo(this.collection, "search:begin", this.searchBegin)
                       .listenTo(this.collection, "search:cancel", this.searchEnd);

        this.input = this.$(".recipe-search-input").focus();

        this.render();
    },

    render: function () {
        this.$(".gravatar-picture").popover({
            html: true,
            title: userName,
            content: "<a class='btn btn-danger' href='/account/logout'><i class='glyphicon glyphicon-off'></i> Log out</a>",
            placement: "left"
        });
    },

    search: function (e) {
        this.collection.search(this.input.val());
    },

    searchBegin: function () {
        $(document.body).addClass("is-searching");
    },

    searchEnd: function () {
        $(document.body).removeClass("is-searching");
    }

});