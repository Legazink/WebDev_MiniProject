$(document).ready(function () {
    $("#view-member").click(function () {

        const postId = $(this).data("post-id");
        const stringId = String(postId);

        $.ajax({
            url: '/Home/GetPostMembers',
            type: 'POST',
            data: { postId: stringId },
            success: function (response) {
                let board = $("#display-member");
                board.empty();
                console.log("No Refreshing");
                response.joinedMembers.result.forEach(function (member) {
                    board.append('<p>' + member.username + '</p>');
                });
            },
            error: function (xhr, status, error) {
                alert('Error')
            }
        });
    });

});