window.onload = function () {
    if ($(".productRequest:not(.onlyMoblile)").length == 0) {
        $(".product-space").remove();
    }
    $(".phoneCode").on("focus", function () {
        $(this).val("+");
    });

    $(".phoneCode").on("blur", function () {
        $(this).val($(this).attr('dataStore'));
    });

    $(".phoneCode").on("keyup", function (e) {
        if (e.which != 9) {
            $(this).attr("dataStore", $(this).val());
        }
    });

    $(".searchBox").on("keyup", function (e) {
        e.preventDefault();
        if (e.keyCode === 13) {
            location.href = '/arama-sonuclari?q=' + $(this).val();
        }
    });

    if ($(".accordion.detail li:eq(0) .aTitle").length > 0) {
        setTimeout(function () {
            $(".accordion.detail li:eq(0) .aTitle").click();
        }, 100);
    }

    $(".lcs_checkbox_switch").on("click", function () {
        $("#hdnUsingMikroSoftware").val($(this).hasClass("lcs_on") ? "False" : "True");
    });
}