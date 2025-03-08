document.addEventListener("DOMContentLoaded", () => {
    const cardContainer = document.getElementById("card-container");
    const likeButton = document.getElementById("like");
    const dislikeButton = document.getElementById("dislike");
    const fightButton = document.getElementById("fight");
    const likedList = document.getElementById("liked-list");
    let characters = [];
    let currentIndex = 0;
    let likedCharacters = [];
  
    fetch("https://rickandmortyapi.com/api/character")
      .then((response) => response.json())
      .then((data) => {
        characters = data.results;
        displayCharacter();
      });
  
    function displayCharacter() {
      if (currentIndex >= characters.length) {
        cardContainer.innerHTML = "<p class='text-xl'>No more characters!</p>";
        return;
      }
  
      const character = characters[currentIndex];
      cardContainer.innerHTML = `
      <div class="swipe-animation absolute inset-0">
        <img src="${character.image}" alt="${character.name}" class="w-full h-3/4 object-cover rounded-t-2xl">
        <div class="p-4">
          <h2 class="text-xl font-semibold">${character.name}</h2>
          <p class="text-gray-400">${character.species}</p>
          <p class="text-gray-400">${character.status}</p>
        </div>
      </div>
    `;
    }
  
    function swipe(direction) {
      const card = cardContainer.firstElementChild;
      card.classList.add(direction === "like" ? "swipe-like" : "swipe-dislike");
  
      setTimeout(() => {
        if (direction === "like") {
          likedCharacters.push(characters[currentIndex]);
          updateLikedList();
        }
        currentIndex++;
        displayCharacter();
      }, 500);
    }
  
    function battle() {
      if (likedCharacters.length < 2) {
        alert("Add at least two characters to start a battle!");
        return;
      }
      let fighter1 =
        likedCharacters[Math.floor(Math.random() * likedCharacters.length)];
      let fighter2 =
        likedCharacters[Math.floor(Math.random() * likedCharacters.length)];
      while (fighter1 === fighter2) {
        fighter2 =
          likedCharacters[Math.floor(Math.random() * likedCharacters.length)];
      }
      cardContainer.innerHTML = `
      <div class="battle-animation h-full">
        <div class="fighter text-center">
          <img src="${fighter1.image}" alt="${fighter1.name}" class="rounded-full w-32 h-32">
          <p>${fighter1.name}</p>
        </div>
        <p class="text-4xl">⚔️</p>
        <div class="fighter text-center">
          <img src="${fighter2.image}" alt="${fighter2.name}" class="rounded-full w-32 h-32">
          <p>${fighter2.name}</p>
        </div>
      </div>
    `;
      setTimeout(() => {
        document
          .querySelectorAll(".fighter")
          [Math.random() > 0.5 ? 0 : 1].classList.add("attack");
        setTimeout(() => {
          alert(`${Math.random() > 0.5 ? fighter1.name : fighter2.name} wins!`);
          displayCharacter();
        }, 500);
      }, 1000);
    }
  
    function updateLikedList() {
      likedList.innerHTML = likedCharacters
        .map((c) => `<li class='text-green-400'>${c.name}</li>`)
        .join("");
    }
  
    likeButton.addEventListener("click", () => swipe("like"));
    dislikeButton.addEventListener("click", () => swipe("dislike"));
    fightButton.addEventListener("click", battle);
  });
  