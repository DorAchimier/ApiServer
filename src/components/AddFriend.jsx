import { useState, useEffect } from "react";
import axios from "axios";
const AddFriend = ( {trigger, handleClose, getUsernames, getNickname, friends, addSend, username} ) => {
    const [query, setQuery] = useState("");
    const [ users, setUsers] = useState([]);

    const getFilteredItems = () => {
        axios.get("https://localhost:7033/" + query).then(res => {
            console.log(res);
            
            setUsers(res.data)
        }).catch(err => {console.log(err)})
        return users;
    }
    const close = () => {
        setRefresh(refresh + 1);
        handleClose();
    }


    const url1 = "https://localhost:7033/api/";
    const url2 = "/contacts"
    const addHandler = (un1, un2) => {
        var data = ({
        "id": un2,
        "name": "nickname",
        "server": "localhost:3000"
      });
    var options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }
    fetch(url1 + un1 + url2, options);
    }

    // const filteredItems = getFilteredItems();

//     useEffect(() => { 
//         axios.get("https://localhost:7033/api/all").then(res => {
//             setUsers(res.data)
//             console.log(res.data);
//         }).catch(err => {console.log(err)})
// }, []);

const [refresh, setRefresh] = useState(0);
useEffect(() => { 
    
}, [refresh]);

    return ( 
        trigger ? 
        (<div className='popup'>
            <div className='popup-inner'>
                <button onClick={() => close()}>X</button>
                <br></br>
                <br></br>
                <input trype="text" placeholder="Enter Username..." onChange={(e) => setQuery(e.target.value)}></input>
                <button onClick={() => getFilteredItems()}>Search</button>
                {users && users.map(friend => (
                <div className="contact-search-preview" key={friend.Id}>
                    <h2>{friend.name}</h2>
                    <h4>{friend.id}</h4>
                    <br></br>
                    <button onClick={() => addHandler(username, friend.id)}>+Add</button>
                </div>
            ))}
            </div>
        </div>) : ""
     );
}
 
export default AddFriend;