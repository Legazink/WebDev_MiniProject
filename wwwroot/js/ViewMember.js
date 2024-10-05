$(document).on('click', '.view-btn', function () {
    const data = $(this).data("id"); 
    console.log(data);

    if (data == "view") {
        const postId = $(this).data("post-id");
        const stringId = String(postId);
        const viewmember = "view-member-" + stringId;
        console.log(viewmember);

        $.ajax({
            url: '/Home/GetPostMembers',
            type: 'POST',
            data: { postId: stringId },
            success: function (response) {
                let display = $(".display-member");
                let board = $(".board-container");

                board.empty();
                display.empty();
                console.log("No Refreshing");

               
                display.addClass("view-member");
                display.append('<p class="header-member">Member</p>');

                let memberDiv = $('<div class="member-container"></div>');
                response.joinedMembers.result.forEach(function (member) {
                    memberDiv.append('<li class="display-member">' + member.username + '</li>');
                });
                display.append(memberDiv);
            },
            error: function (xhr, status, error) {
                alert('Error');
            }
        });
    } else {
        console.log("Notpass");
    }
});
