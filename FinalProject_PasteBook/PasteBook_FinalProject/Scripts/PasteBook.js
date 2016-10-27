$(document).ready(function () {
    GetNotificationCount();

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

function Notification(notificationType, post_ID, comment_ID, IDtoBeFried) {
    var data = {
        notifType: notificationType,
        postID: post_ID,
        commentID: comment_ID,
        friendRequestID: IDtoBeFried
    }

    $.ajax({
        url: getNotificationUrl,
        data: data,
        type: 'GET',
        success: function () {
            Reload();
            NotifyFriend();
            GetNotificationCount();
        }
    })
};

function NotifyFriend() {
    $.ajax({
        url: getGetNotificationListUrl,
        type: 'GET',
        success: function () {
            Reload();
        }
    })
};

function GetNotificationCount() {
    $.ajax({
        url: getGetNotificationCountUrl,
        type: 'GET',
        success: function (data) {
            RefreshBadge(data);
        }
    })
};

function RefreshBadge(data) {
    if (data.NotifCount != 0) {
        $('#globeBadge').text(data.NotifCount)
    }
}




//Preview profile picture
//stackoverflow.com/questions/4459379/preview-an-image-before-it-is-uploaded
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