$(document).ready(function () {
    $('#btnPost').click(function () {
        var data = {
            post: $('#txtPost').val()
        }
        if ($('#txtPost').val() != null) {
            $.ajax({
                url: getCreatePostUrl,
                data: data,
                type: 'GET',
                success: function () {
                    Reload();
                }
            })
        }
    })
});

function AddLike(ID) {
    var data = {
        postID: ID
    };

    $.ajax({
        url: getLikePostUrl,
        data: data,
        type: 'GET',
        success: function () {
            Reload();
        }
    })
};

function AddComment(ID, button) {
    var data = {
        postID: ID,
        postContent: $('#txtComment'.concat(button.value)).val()
    };

    $.ajax({
        url: getCommentPostUrl,
        data: data,
        type: 'GET',
        success: function () {
            Reload();
        }
    })
};

function Notification(notificationType, post_ID, comment_ID) {
    alert(notificationType + post_ID + comment_ID)
    var data = {
        notifType: notificationType,
        postID: post_ID,
        commentID: comment_ID
    }

    $.ajax({
        url: getNotificationUrl,
        data: data,
        type: 'GET',
        success: function () {
            Reload();
        },
        error:
            alert('error')
    })
};

$("#uploadImage").on('change', function () {
    if (typeof (FileReader) != "undefined") {
        var image_holder = $("#imageHolder");
        image_holder.empty();

        var reader = new FileReader();
        reader.onload = function (e) {
            $("<img />", {
                "src": e.target.result,
                "class": "thumb-image"
            }).appendTo(image_holder);
        }
        image_holder.show();
        reader.readAsDataURL($(this)[0].files[0]);
    } else {
        alert("This browser does not support FileReader.");
    }
});

function Search() {
    location.href = url + '/?searchValue=' + $('#txtSearch').val()
};

function Reload() {
    $('#refreshPartialView').load(getRefreshPartialViewUrl);
    $('#txtPost').val("");
    $('#txtComment').val("");
};