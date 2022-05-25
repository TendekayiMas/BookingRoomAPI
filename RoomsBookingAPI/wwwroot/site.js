const uri = 'api/roomsbookingapi'
let rooms = [];

function getRooms(){
    fetch(uri)
    .then(response => response.json())
    .then(data=> _displayRooms(data))
    .catch(error => console.error('unable to get room.', error));

}

function addRoom(){
    const addRoomTextbox = document.getElementById('add-Room');

    const room = {
        isComplete: false,
        roomNum: addRoomTextbox.value.trim()

    };

    fetch(uri, {
        method: 'POST',
        headers:{
            'Accept': 'application/json',
            'content-type': 'application/json'
        },
        body: JSON.stringify(room)

    })
     .then(response => response.json())
     .then(() =>{
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