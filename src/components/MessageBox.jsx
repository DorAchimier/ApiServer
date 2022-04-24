import { useState } from "react";

const MessageBox = ({ username , pressedContact , pUsername , getConversations, getConversation}) => {
    const [msg, setMsg] = useState('');
    const s = "sent";
    const r = "received";
    let mid;

    const con = getConversation(username,pUsername);
    
    return ( 
        <div className="message-box">
            <div className="message-box-contact">
                <h2>{pressedContact}</h2>
            </div>
            <textarea type="text" placeholder="Type here..." onChange={(e) => setMsg(e.target.value)}/>
            <button>send</button>
            <div className="message-box-conversation">
                {con.map(msgDetails => ( 
                    <div className="message" key={msgDetails.id}>
                        <div className="disappear">
                        {(msgDetails.sender === pUsername) ? mid = r : mid = s}
                        {(msgDetails.sender === "ADMIN") ? mid = "admin" : mid}
                        </div>
                        <div className={`message ${mid}`}>{msgDetails.message}</div>
                        <div className={`message ${mid}-time`}>{msgDetails.time}</div>
                    </div>
                ))}
            </div>
        </div>
     );
}
 
export default MessageBox;