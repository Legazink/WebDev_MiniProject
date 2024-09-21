const dropdowns = document.querySelectorAll('.dropdown');

    dropdowns.forEach(dropdowns => {
        const select = dropdowns.querySelector('.select');
        const caret = dropdowns.querySelector('.caret');
        const menu = dropdowns.querySelector('.menu');
        const options = dropdowns.querySelectorAll('.menu li');
        const selected = dropdowns.querySelector('.selected');
        const img = document.getElementById('game-img')

        select.addEventListener('click', () => {
            select.classList.toggle('select-clicked');
            caret.classList.toggle('caret-rotate');
            menu.classList.toggle('menu-open');
        });

        options.forEach(options => {
            options.addEventListener('click', () => {
                selected.innerText = options.innerText;
                select.classList.remove('select-clicked');
                caret.classList.remove('caret-rotate');
                menu.classList.remove('menu-open');

                const Newimg = options.getAttribute('data-image');
                img.src = Newimg;
                options.forEach(option => {
                    option.classList.remove('active');
                });
                option.classList.add('active');
            });
        });
    });