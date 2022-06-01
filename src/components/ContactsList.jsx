import { useEffect, useState } from "react";
import AddFriend from "./AddFriend";
import axios from "axios";

const ContactsList = ({username, clickHandle, getLastMessage, getUsernames, getNickname, addSend}) => {

    const [buttonPopup, setButtonPopup] = useState(false);
    const [ contacts, setContacts ] = useState([]);

    let url1 = "https://localhost:7033/api/"
    let url2 = "/contacts"

    const togglePopup = () => {
        addSend();
        setButtonPopup(!buttonPopup);
    }

    const dateSort = (array) => {
        return array.sort((a, b) => b.last - a.last).reverse();
    }


    useEffect(() => { 
            axios.get(url1 + username + url2).then(res => {
                console.log(res)
                setContacts(res.data)
            }).catch(err => {console.log(err)})
    }, []);

    return ( 
        <div className="contacts-block">
            <div>
                <div className="add-friend" onClick={() => togglePopup()}>
                <h2>+ Start New Chat</h2>
                </div>
                <AddFriend trigger={buttonPopup} handleClose={togglePopup} getUsernames={getUsernames} getNickname={getNickname} friends={contacts} addSend={addSend} username={username}/> 
            </div>
            
            {contacts && contacts.map(friend => (
                <div className="contact-preview" key={friend.id} onClick={() => clickHandle(friend.id)}>
                    <h2>{friend.name}</h2>
                    <h4>{friend.last}</h4>
                    {/* {friend.type !== "text" && <h4>{friend.type}</h4>} */}
                    {/* <img src={friend.photo} width="100" height="100" alt="profile-pic"/> */}
                    {console.log(friend.last)}
                    {friend.last != "" && <div className="contact-preview-time">{friend.lastDate}</div>}
                </div>
            ))}
        </div>
        
     );
}
 
export default ContactsList;

