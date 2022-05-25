const uri = 'https://localhost:7108'
let rooms = [];

function getRooms() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayRooms(data))
        .catch(error => console.error('unable to get room.', error));

}

function addRoom() {
    const addRoomTextbox = document.getElementById('add-Room');

    const room = {
        isComplete: false,
        roomNum: addRoomTextbox.value.trim()

    };

    fetch(uri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'content-type': 'application/json'
            },
            body: JSON.stringify(room)

        })
        .then(response => response.json())
        .then(() => {
            getRooms();
            addRoomTextbox.value = '';
        })
        .catch(error => console.error('unable to add room.', error));

}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
            method: 'DELETE'
        })
        .then(() => getRooms())
        .catch(error => console.error('Unable to delete Room.', error));
}

function displayEditForm(id) {
    const room = rooms.find(room => room.id === id);

    document.getElementById('edit-Room').value = room.roomNum;
    document.getElementById('edit-id').value = room.id;
    document.getElementById('edit-isComplete').checked = room.isComplete;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const RoomId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(RoomId, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-Room').value.trim()
    };

    fetch(`${uri}/${RoomId}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(room)
        })
        .then(() => getRooms())
        .catch(error => console.error('Unable to update room.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(RoomCount) {
    const roomNum = (RoomCount === 1) ? 'to-book' : 'to-book';



    document.getElementById('counter').innerText = `${RoomCount} ${roomNum}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('rooms');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(room => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${room.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${room.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(room.roomNum);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    rooms = data;
}