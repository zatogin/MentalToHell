// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#menu-open").click(function () {
    $("#main-menu-hidden").removeClass("hidden");
});

$("#menu-close").click(function () {
    $("#main-menu-hidden").addClass("hidden");
});

$(".show-state-main").click(function () {
    $(".state-main").slideUp();
    $(".header-choose").slideUp();
    $(".statemain-hidden").slideDown().delay(1000);
    $(".header-chosen").slideDown();
    $(".statemain-hidden").removeClass("hidden").delay(800);
});