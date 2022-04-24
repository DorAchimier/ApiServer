import { useState } from "react";
import useFetch from "./useFetch";
const ContactsList = ({user, clickHandle, getDB, getLastMessage, getUsernames}) => {

    const [query, setQuery] = useState("");

    const contacts = user && getLastMessage(user.username, user.contacts);

    const getFilteredItems = (q, items) => {
        if (q === "") {
            return items;
        }
        return items.filter(u => u.includes(query));
    }

    const filteredItems = getFilteredItems(query, getUsernames());

    const addFriendHandler = () => {
        {console.log(filteredItems)}
        <div>
            <label>Search</label>
            <input type="text" onChange={(e) => setQuery(e.target.value)} />
            <h1>{filteredItems}</h1>
        </div>
    }

    return ( 
        <div className="contacts-block">
            <input type="text" onChange={(e) => setQuery(e.target.value)} />
            <div className="add-friend" onClick={() => addFriendHandler()}>
                <h2>+Add Friend</h2>
            
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

