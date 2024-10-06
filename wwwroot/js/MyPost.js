const myPosts = window.myPosts;

myPosts.forEach(post => {
    const postId = post.postId;
    console.log("isclosed", post.isClosed)

    if (post.isClosed == true) {
        var selector = "#close-button-";
        selector += postId;
        const button = document.querySelector(selector);

        button.style.backgroundColor = "Gray";
        button.style.cursor = "auto";
        button.disabled = true;
        button.innerText = "CLOSED";
    }
});
