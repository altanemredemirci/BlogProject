$(function () {
    var blogids = [];

    $("div[data-blog-id]").each(function (i, e) {
        blogids.push($(e).data("blog-id"));
    })


    $.ajax({
        method: "POST",
        url: "/Blog/GetLiked",
        data: { ids: blogids }
    }).done(function (data) {
        if (data.result != null && data.result.length > 0) {
            for (var i = 0; i < data.result.length; i++) {
                var id = data.result[i];
                var likedBlog = $("div[data-blog-id=" + id + "]");
                var btn = likedBlog.find("button[data-liked]");
                var span = btn.find("span.like-star");

                btn.data("liked", true);
                span.removeClass("glyphicon-star-empty");
                span.addClass("glyphicon-star")
            }
        }
    }).fail(function () { })

    $("button[data-liked]").click(function () {
        var btn = $(this);
        var blogid = btn.data("blog-id");
        var spanStar = btn.find("span.like-star");
        var liked = btn.data("liked");
        var spanCount = btn.find("span.like-count")

        $.ajax({
            method: "post",
            url: "/Blog/SetLikeState",
            data: { "blogid": blogid, "liked": !liked }
        }).done(function (data) {
            if (data.hasError) {
                alert(data.errorMessage);
            } else {
                liked = !liked;
                console.log(liked)
                btn.data("liked", liked);
                spanCount.text(data.result);

                spanStar.removeClass("glyphicon-star-empty");
                spanStar.removeClass("glyphicon-star");

                if (liked == false) {
                    spanStar.addClass("glyphicon-star-empty");
                }
                else {
                    spanStar.addClass("glyphicon-star");
                }
            }
        }).fail(function () {
            alert("Sunucu ile bağlantı kurulamadı.")
        })
    })
})