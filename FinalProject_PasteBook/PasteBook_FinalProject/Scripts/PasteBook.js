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
                },
                error: function () {
                    alert('Something went wrong.')
                }
            })
        }
    })
});

function AddLike(postID) {
    var data = {
        postID: ID
    };

    $.ajax({
        url: getLikePostUrl,
        data: data,
        type: 'GET',
        success: function () {
            Reload();
        },
        error: function () {
            alert('Something went wrong.')
        }
    })
};

function AddComment(ID) {
    var data = {
        postID: ID,
        postContent: $('#txtComment').val()
    };

    $.ajax({
        url: getCommentPostUrl,
        data: data,
        type: 'GET',
        success: function () {
            Reload();
        },
        error: function () {
            alert('Something went wrong.')
        }
    })
};


function Reload() {
    $('#refreshPartialView').load(getRefreshPartialViewUrl);
    $('#txtPost').val("");
    $('#txtComment').val("");
};