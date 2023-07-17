(() => {
    let cardTitle = $('.card-title')[0];
    if (!cardTitle) return;

    const Velocitys = { value: 0 };
    gsap.to(Velocitys, {
        value: 1000,
        duration: 2,
        ease: 'sine.out',
        onUpdate: () => {
            let step = Math.floor(Velocitys.value / 50);
            cardTitle.textContent = list[step % list.length];
        },
        onComplete: () => {
            cardTitle.textContent = modelName;
        },
    });
})()