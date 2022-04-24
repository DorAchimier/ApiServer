import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import Navbar from "./Navbar";
import ContactsList from "./ContactsList";
import MessageBox from "./MessageBox";

const MyChat = ( { getDB , getConversations, getConversation, getLastMessage, getNickname, getUsernames } ) => {
    const { username } = useParams();
    const db = getDB(); 

    const [ pressedContact, setPressedContact ] = useState(null);
    const [ pUsername, setPUsername ] = useState(null);
    const userDetails = db.find((u) => u.username === username);

    useEffect(() => {
        {pressedContact && <MessageBox username={username} pressedContact={pressedContact} pUsername={pUsername} getConversations={getConversations}/>}
    }, [pressedContact]);
    
    const clickHandle = (friend) => {
        setPressedContact(getNickname(friend.username));
        setPUsername(friend.username);
    }

    return ( 
        <div className="App">
            <Navbar pageName="Sign Out" pageRef="/" />
            <div className="chat-screen">
                <ContactsList user={userDetails} clickHandle={clickHandle} getLastMessage={getLastMessage} getUsernames={getUsernames}/>
                {pressedContact && <MessageBox username={username} pressedContact={pressedContact} pUsername={pUsername} getConversations={getConversations} getConversation={getConversation}/>}
            </div>
        </div>
     );
}
 
export default MyChat;