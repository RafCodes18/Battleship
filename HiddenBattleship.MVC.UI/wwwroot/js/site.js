// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

 /*-------------------------------------
 |                                     |
 |   built by: rafael parra  2023      |     
 |                                     |        
 |                                     |             
 |____________________________________*/


// MAIN GAME LOGIC //
const shipContainer = document.querySelector('.ships-container')
const btnFlip = document.querySelector('#btnFlip')
const btnStart = document.querySelector('#btnStart')
const gamesContainer = document.querySelector('#games-container')
const infoDisplay = document.querySelector('#info');
const turnDisplay = document.querySelector('#turn-display');

let playerHits = [];
let computerHits = [];

const playerSunkShips = [];
const computerSunkShips = [];

let gameOver = false;
let playerTurn;

btnFlip.addEventListener('click', flip)

let angle = 0;
function flip() {
    const ships = Array.from(shipContainer.children)
    //if angle == 0, change to 90, else keep 0
    angle = angle === 0 ? 90 : 0
    //rotate all ships
    ships.forEach(ship => ship.style.transform = `rotate(${angle}deg)`)
}


//creating boards
const width = 10;

function createBoard(color, user) {
    const gameBoardContainer = document.createElement('div')
    gameBoardContainer.classList.add('game-board')
    //gameBoardContainer.style.backgroundColor = color
    gameBoardContainer.id = user

    //   loop to create 100 blocks in the game board
    for (let i = 0; i < width * width; i++) {
        const block = document.createElement('div');
        block.classList.add('block');
        block.id = i;
        gameBoardContainer.append(block);
    }

    gamesContainer.append(gameBoardContainer)
}

createBoard('#6B5B95', 'player')
createBoard('#34568B', 'computer')

class Ship {
    constructor(name, length) {
        this.name = name
        this.length = length
    }
}

const ship1 = new Ship('ship1', 2)
const ship2 = new Ship('ship2', 3)
const ship3 = new Ship('ship3', 3)
const ship4 = new Ship('ship4', 4)
const ship5 = new Ship('ship5', 5)

const ships = [ship1, ship2, ship3, ship4, ship5]
let notDropped;

function getValidity(allBoardBlocks, isHorizontal, startIndex, ship) {
    //keep pieces inside the board
    // if ship is horizontal, check if its less than or == to 100 - ship length. if not, push it to valid pos
    let validStart = isHorizontal ? startIndex <= width * width - ship.length ? startIndex : width * width - ship.length :
        // handle vertical
        startIndex <= width * width - width * ship.length ? startIndex : startIndex - ship.length * width + width

    //array of ships
    let shipBlocks = []

    for (let i = 0; i < ship.length; i++) {
        if (isHorizontal) {
            shipBlocks.push(allBoardBlocks[Number(validStart) + i])
        } else {
            shipBlocks.push(allBoardBlocks[Number(validStart) + i * width])
        }
    }

    let valid;
    //make sure blocks dont overlap or split
    if (isHorizontal) {
        shipBlocks.every((_shipBlock, index) =>
            valid = shipBlocks[0].id % width !== width - (shipBlocks.length - (index + 1)))
    } else {
        shipBlocks.every((_shipBlock, index) =>
            valid = shipBlocks[0].id < 90 + (width * index + 1))
    }

    const notTaken = shipBlocks.every(shipBlock => !shipBlock.classList.contains('taken'))

    return { shipBlocks, valid, notTaken }
}



function addShipPiece(user, ship, startId) {
    const allBoardBlocks = document.querySelectorAll(`#${user} div`)
    let randomBoolean = Math.random() < 0.5
    let isHorizontal = user === 'player' ? angle === 0 : randomBoolean

    let randomStartIndex = Math.floor(Math.random() * width * width)
    let startIndex = startId ? startId : randomStartIndex

    const { shipBlocks, valid, notTaken } = getValidity(allBoardBlocks, isHorizontal, startIndex, ship);

    if (valid && notTaken) {
        shipBlocks.forEach(shipBlock => {
            shipBlock.classList.add(ship.name)
            shipBlock.classList.add('taken')
        })
    } else {
        if (user === 'computer') addShipPiece(user, ship, startId)
        if (user === 'player') notDropped = true
    }

}
ships.forEach(ship => addShipPiece('computer', ship))

//drag player ships
let draggedShip;
const optionShips = Array.from(shipContainer.children)
optionShips.forEach(ship => ship.addEventListener('dragstart', dragStart))

const allPlayerBlocks = document.querySelectorAll('#player div')
allPlayerBlocks.forEach(playerBlock => {
    playerBlock.addEventListener('dragover', dragOver)
    playerBlock.addEventListener('drop', dropShip)
})

function dragStart(e) {
    draggedShip = e.target
    notDropped = false
}

function dragOver(e) {
    e.preventDefault()
    const ship = ships[draggedShip.id]
    highlightArea(e.target.id, ship)
}

function dropShip(e) {
    const startId = e.target.id
    const ship = ships[draggedShip.id]
    addShipPiece('player', ship, startId)
    if (!notDropped) {
        draggedShip.remove()
    }


    // Check if all 5 ships have been placed
    if (document.querySelectorAll('#player .taken').length === 17) {
        // Change the text of the "info" div to "Press Start"
        infoDisplay.textContent = "Press Start";
    }
}

ships.forEach(ship => addShipPiece(ship))


//add highlight
function highlightArea(startIndex, ship) {
    const allBoardBlocks = document.querySelectorAll('#player div');
    let isHorizontal = angle === 0

    const { shipBlocks, valid, notTaken } = getValidity(allBoardBlocks, isHorizontal, startIndex, ship)

    if (valid && notTaken) {
        shipBlocks.forEach(ship => {
            ship.classList.add('hover')
            setTimeout(() => ship.classList.remove('hover'), 500)
        })
    }
}

function startGame() {
    // Add logic to start the game here        

    // Hide the "Flip Pieces" button
    if (btnStart.innerText == "End Game") {

        //End the game
        location.reload();

        btnStart.innerText = "Start Game";
        btnFlip.style.visibility = "hidden"; // Make button visible
        btnStart.style = "background-color:#55d6be; ";
    } else {
        //only start game if pieces have been placed
        if (shipContainer.children.length != 0) {
            infoDisplay.textContent = "Drag ships to your board to start"
        } else {
            //now that pieces have been placed, start the game
            let info = document.querySelector(".info");
            info.textContent="Click a square on the opponents board.";
            infoDisplay.textContent = "Begin! "
            playerTurn = true;

            const allBoardBlocks = document.querySelectorAll('#computer div');
            allBoardBlocks.forEach(block => block.addEventListener('click', handleClick));


            //change buttons to reflect state of game
            shipContainer.style.visibility = "hidden";
            btnFlip.style.visibility="hidden";
            console.log("start game clicked");
            btnStart.innerText = "End Game";
            btnStart.style = "background-color: red;"
        }
    }
}


function handleClick(e) {
    if (!gameOver) {
        if (e.target.classList.contains('taken')) {
            e.target.classList.add('boom');
            infoDisplay.textContent = "You hit the computers ship!";

            let classes = Array.from(e.target.classList);
            classes = classes.filter(className => className !== 'block');
            classes = classes.filter(className => className !== 'boom');
            classes = classes.filter(className => className !== 'taken');

            playerHits.push(...classes)
            console.log(playerHits);
            checkScore('player', playerHits, playerSunkShips)
        }

        if (!e.target.classList.contains('taken')) {
            infoDisplay.textContent = "You missed!";
            e.target.classList.add('empty');
        }

        playerTurn = false;

        const allBoardBlocks = document.querySelectorAll('#computer div');
        allBoardBlocks.forEach(block => block.replaceWith(block.cloneNode(true)));
        setTimeout(computerGo, 3000);
    }
}

let computerLastHit = null;
//Computer move logic
function computerGo() {
    if (!gameOver) {
        infoDisplay.textContent = "Computer thinking...";

        setTimeout(() => {
            let randomGo = Math.floor(Math.random() * width * width);
            const allBoardBlocks = document.querySelectorAll('#player div');

            if (allBoardBlocks[randomGo].classList.contains('taken') &&
                allBoardBlocks[randomGo].classList.contains('boom')) {
                computerGo()
                return;
            } else if (allBoardBlocks[randomGo].classList.contains('taken') &&
                !allBoardBlocks[randomGo].classList.contains('boom')) {
                allBoardBlocks[randomGo].classList.add('boom')
                infoDisplay.textContent = 'Computer hit your ship!';

                let classes = Array.from(allBoardBlocks[randomGo].classList);
                classes = classes.filter(className => className !== 'block');
                classes = classes.filter(className => className !== 'boom');
                classes = classes.filter(className => className !== 'taken');

                computerHits.push(...classes);
                checkScore('computer', computerHits, computerSunkShips)


            } else {
                infoDisplay.textContent = "Computer missed!";
                allBoardBlocks[randomGo].classList.add('empty');
            }
        }, 2000);

        setTimeout(() => {
            playerTurn = true;
            infoDisplay.textContent = "Make your move. ";

            const allBoardBlocks = document.querySelectorAll('#computer div')
            allBoardBlocks.forEach(block => block.addEventListener('click', handleClick));
        }, 4000)
    }
}

function checkScore(user, userHits, userSunkShips) {
    function checkShip(shipName1, shipLength) {
        if (
            userHits.filter(storedShipName => storedShipName === shipName1).length === shipLength
        ) {
            var shipName;
            if (user === 'player') {
                switch (shipName1) {
                    case 'ship1':
                        shipName = `smallest ship!`;
                        break;
                    case 'ship2':
                        shipName = "second smallest ship!";
                        break;
                    case 'ship3':
                        shipName = "third largest ship!";
                        break;
                    case 'ship4':
                        shipName = "second largest ship!";
                        break;
                    case 'ship5':
                        shipName = "largest ship!";
                        break;
                    default:
                        break;
                }
                infoDisplay.textContent = `You sunk the computers ${shipName}`;
                playerHits = userHits.filter(storedShipName => storedShipName !== shipName1)
            }
            if (user === 'computer') {
                infoDisplay.textContent = `The computer sunk your ${shipName}`;
                computerHits = userHits.filter(storedShipName => storedShipName !== shipName1)
            }
            userSunkShips.push(shipName1);
        }
    }

    checkShip('ship1', 2)
    checkShip('ship2', 3)
    checkShip('ship3', 3)
    checkShip('ship4', 4)
    checkShip('ship5', 5)

    console.log('player hits', playerHits)
    console.log('player sunk ships', playerSunkShips)

    if (playerSunkShips.length === 5) {
        infoDisplay.textContent = 'You sunk all computer ships. You WIN!';
        infoDisplay.style = "font-weight: y00;";
        infoDisplay.style = "color:#4EB300 !important";
        gameOver = true;
    }
    if (computerSunkShips.length === 5) {
        infoDisplay.textContent = 'The computer sunk all your ships. You LOSE!';
        gameOver = true;
    }
}


