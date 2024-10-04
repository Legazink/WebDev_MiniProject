const postData = window.postData;
const currentUser = window.currentUser;

postData.forEach(post => {
    const postId = post.postId;
    //console.log(post.gameName);
    //console.log(post.joinedNumber);
    //console.log(post.number);
    if (post.postOwner == currentUser || post.joinedNumber == post.number)
    {
        var selector = "#join-button-";
        selector += postId;
        button = document.querySelector(selector);

        button.disabled = true;
        button.style.backgroundColor = "Gray";
        button.style.cursor = "auto";
        button.innerText = "JOINED";
    }
    else {
        post.postJoinedAll.forEach(joined => {
            if (joined.joinedUserName == currentUser) {
                var selector = "#join-button-";
                selector += postId;
                button = document.querySelector(selector);

                button.disabled = true;
                button.style.backgroundColor = "Gray";
                button.style.cursor = "auto";
                button.innerText = "JOINED";
            }
        });
    }
});