var AddContainerPopoverTemplate = require("../templates/addContainerPopover.html");

module.exports = Backbone.View.extend({

    el: "#containers-search",

    events: {
        "keyup #new-container-name": "createContainer",
        "keyup .containers-search-input": "searchContainers"
    },

    initialize: function () {
        this.initializePopover();
    },

    initializePopover: function () {
        var template = _.template(AddContainerPopoverTemplate);

        this.$(".btn-add-container").popover({
            html: true,
            content: template(),
            placement: "left",
            container: this.el
        }).on("shown.bs.popover", function () {
            document.querySelector("#new-container-name").focus();
        });
    },

    createContainer: function (e) {
        if (e.keyCode !== 13) {
            return true;
        }

        this.collection.create({
            Name: e.target.value
        }, { wait: true });

        e.target.value = "";
    },

    searchContainers: function (e) {
        var query = e.target.value;

        if (e.keyCode === 13) {
            e.preventDefault();
            return;
        }

        App.trigger("containers:search", $.trim(e.target.value).toLowerCase());
    }

});