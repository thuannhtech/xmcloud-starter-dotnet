/**
 * BannerSlider initialisation.
 * Each .banner-swiper element should carry the following data attributes:
 *   data-slider-id   – the element's own id
 *   data-prev-id     – id of the "previous" button
 *   data-next-id     – id of the "next" button
 *   data-pagin-id    – id of the pagination container
 *   data-pp-id       – id of the play/pause button
 */
(function () {
    'use strict';

    document.querySelectorAll('.banner-swiper[data-slider-id]').forEach(function (el) {
        // Skip Swiper init when rendered in Sitecore editing mode
        if (el.dataset.editing === 'true') return;

        var sliderId = el.dataset.sliderId;
        var prevId = el.dataset.prevId;
        var nextId = el.dataset.nextId;
        var paginId = el.dataset.paginId;
        var ppId = el.dataset.ppId;

        var swiper = new Swiper('#' + sliderId, {
            loop: true,
            speed: 600,
            autoplay: { delay: 5000, disableOnInteraction: false },
            navigation: { prevEl: '#' + prevId, nextEl: '#' + nextId },
            pagination: { el: '#' + paginId, clickable: true }
        });

        /* Play / Pause Logic */
        var btn = document.getElementById(ppId);
        var isPlaying = true;
        if (btn) {
            btn.addEventListener('click', function () {
                if (isPlaying) { swiper.autoplay.stop(); } else { swiper.autoplay.start(); }
                btn.querySelector('.icon-pause').style.display = isPlaying ? 'none' : 'block';
                btn.querySelector('.icon-play').style.display = isPlaying ? 'block' : 'none';
                isPlaying = !isPlaying;
            });
        }
    });
})();
