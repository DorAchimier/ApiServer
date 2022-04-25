import { useState } from "react";
import AddFriend from "./AddFriend";
const ContactsList = ({user, clickHandle, getDB, getLastMessage, getUsernames, getNickname, addFriend}) => {

    const [buttonPopup, setButtonPopup] = useState(false);

    const togglePopup = () => {
        setButtonPopup(!buttonPopup);
    }

    const contacts = user && getLastMessage(user.username, user.contacts);

    return ( 
        <div className="contacts-block">
            {/* <input type="text" placeholder="Enter username" onChange={(e) => setQuery(e.target.value)} /> */}
            <div>
                <div className="add-friend" onClick={() => togglePopup()}>
                <h2>+ Start New Chat</h2>
                </div>
                <AddFriend trigger={buttonPopup} handleClose={togglePopup} getUsernames={getUsernames} getNickname={getNickname} friends={user.contacts + user.username} addFriend={addFriend} username={user.username}/> 
            </div>
            
            {contacts && contacts.map(friend => (
                <div className="contact-preview" key={friend.username} onClick={() => clickHandle(friend)}>
                    <h2>{friend.nickname}</h2>
                    <h4>{friend.message}</h4>
                    <div className="contact-preview-time">{friend.time}</div>
                </div>
            ))}
        </div>
        
     );
}
 
export default ContactsList;

