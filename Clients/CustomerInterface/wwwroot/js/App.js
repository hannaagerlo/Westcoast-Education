'use strict';


const modalDialog = document.querySelector('.modal'); //Dialogruta
const closeModalButton = document.querySelector('.close-modal'); //Knappen X i dialogrutan
const overlay = document.querySelector('.overlay');

const loadImages = () => {
  const images = document.querySelectorAll('.gallery-card img');

  //Loopa igenom alla bilder och knyt en klick händelse på varje bild...
  images.forEach((image) => {
    let baseUrl = image.baseURI.endsWith('#')
      ? image.baseURI.slice(0, -1)
      : image.baseURI;

    let src = image.getAttribute('src');
    let id = image.getAttribute('courseId');
    let url = `${baseUrl}/Details/${id}`;
    image.addEventListener('click', () => {
      openModal(src, url);
    });
  });
};

const openModal = (imageSrc, url) => {
  const placeholder = modalDialog.querySelector('.modal-container');
  placeholder.innerHTML = `<img src="${imageSrc}" alt="Kurs"/>
  <a class="btn" href="${url}">Mer Info</a>`;

  modalDialog.classList.remove('hidden');
  overlay.classList.remove('hidden');
};

const closeModal = () => {
  modalDialog.classList.add('hidden');
  overlay.classList.add('hidden');
};


closeModalButton.addEventListener('click', closeModal);
document.addEventListener('keyup', (e) => {
  if (e.key === 'Escape') {
    if (!modalDialog.classList.contains('hidden')) closeModal();
  }
});

loadImages();
