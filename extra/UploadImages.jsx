import React ,{useState,useEffect} from 'react'

export default function UploadImage(){
    const [images,setImage] = useState([]);
    const [imageURLs,setImageURLs] = useState([]);
    const [count, setCount] = useState(1);


   useEffect(() => {
       if (images.length < 1) return;
       const newImageUrls = [];
       images.forEach(image => newImageUrls.push({key:count, value:URL.createObjectURL(image)}));
       setCount(count+1);
       setImageURLs(newImageUrls);
   } ,[images]);




    function onImageChange(e) {
        setImage([...e.target.files]);

    }
    return(
        <>
        <input type="file" multiple accept="image/*" onChange={onImageChange}/>
        { imageURLs.map(imageSrc => <img key={imageSrc.key} src={imageSrc.value}/>)}
        </>
    );
}