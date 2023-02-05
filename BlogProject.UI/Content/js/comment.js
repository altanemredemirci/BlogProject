var blogid = -1;
var modalCommentBodyId = "#modal_comment_body";

$(function () {
    $('#modal_comment').on('show.bs.modal', function (e) {

        var btn = $(e.relatedTarget);
        blogid = btn.data("blog-id");

        $(modalCommentBodyId).load("/Comment/ShowBlogComments/" + blogid);
    })
})


function doComment(btn, e, commentid, spanid) {
    var button = $(btn);
    var mode = button.data("edit-mode")

    if (e === "edit_clicked") {
        if (!mode) {
            button.data("edit-mode", true);
            button.removeClass("btn-warning");
            button.addClass("btn-success");
            var btnSpan = button.find("span");
            btnSpan.removeClass("glyphicon-edit")
            btnSpan.addClass("glyphicon-ok")

            $(spanid).attr("contenteditable", true);
        }
        else {
            button.data("edit-mode", false);
            button.removeClass("btn-success");
            button.addClass("btn-warning");
            var btnSpan = button.find("span");
            btnSpan.removeClass("glyphicon-ok")
            btnSpan.addClass("glyphicon-edit")

            $(spanid).attr("contenteditable", false);

            var txt = $(spanid).text();

            $.ajax({
                method: "POST",
                url: "/Comment/Edit/" + commentid,
                data: { text: txt }
            }).done(function (data) {
                if (data.result) {
                    $(modalCommentBodyId).load("/Comment/ShowBlogComments/" + blogid);
                }
                else {
                    alert("Yorum güncellenemedi.");
                }
            }).fail(function () {
                alert("Sunucu ile bağlantı kurulanamadı.")
            });

        }

    }

    else if (e === "delete_clicked") {
        var dialog_res = confirm("Yorum silinsin mi?");
        if (!dialog_res) return false;

        $.ajax({
            method: "GET",
            url: "/Comment/Delete/" + commentid
        }).done(function (data) {
            if (data.result) {
                $(modalCommentBodyId).load("/Comment/ShowBlogComments/" + blogid);
            }
            else {
                alert("Yorum silinemedi.");
            }
        }).fail(function () {
            alert("Sunucu ile bağlantı kurulanamadı.")
        });
    }

    else if (e === "new_clicked") {

        var txt = $("#new_comment_text").val();

        $.ajax({
            method: "POST",
            url: "/Comment/Create",
            data: { "text": txt, "blogid": blogid }
        }).done(function (data) {
            if (data.result) {
                $(modalCommentBodyId).load("/Comment/ShowBlogComments/" + blogid);
            }
            else {
                alert("Yorum eklenemedi.");
            }
        }).fail(function () {
            alert("Sunucu ile bağlantı kurulanamadı.")
        });
    }
}
