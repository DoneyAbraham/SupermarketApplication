module.exports = Backbone.View.extend({

    el: "#login-jumbotron",

    events: {
        "click .btn-register": "showRegisterForm",
        "submit form": "submit"
    },

    initialize: function () {
        this.form = this.$("form");
        this.registerFormFields = this.$(".hide");
        this.loginButtons = this.$(".btn-login, .btn-register");
    },

    showRegisterForm: function (e) {
        e.preventDefault();
        this.registerFormFields.removeClass("hide");
        this.loginButtons.addClass("hide");
        this.form.attr("action", "/Account/Register");
    },

    submit: function () {
        this.$(".btn-login").button("loading");
    }

});