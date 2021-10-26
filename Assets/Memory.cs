using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO.MemoryMappedFiles;

public class Memory : MonoBehaviour
{

    public Text OpenSuccess;
    public Text Accessortest;
    public Text Space;
    public Image image;
    public Image faceimage;
    public Text hrText;
    public Text rrText;
    public Text faceText;
    bool keydown = false;
    Byte[] ColorData = new Byte[640 * 480 * 3];
    Byte[] FaceData = new Byte[1];// (1);
 
    void Start()
    {
  
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && keydown == false)
        {

            keydown = true; 
            Space.text = keydown.ToString();
            
            var camera = MemoryMappedFile.OpenExisting("SM_IMAGE_DATA");
            var time = MemoryMappedFile.OpenExisting("SM_IMAGE_TIME");
            OpenSuccess.text =  camera.ToString();
            
            if (camera != null)
            {
                var accessor = camera.CreateViewAccessor();
                accessor.ReadArray(0, ColorData, 0, ColorData.Length);
              
                var accessor2 = time.CreateViewAccessor();
                long timedata = accessor2.ReadInt64(0);

                Texture2D Tex = new Texture2D(640, 480, TextureFormat.RGB24, false);
                Tex.LoadRawTextureData(ColorData);
                Tex.Apply();
                Rect rect = new Rect(0, 0, 640, 480);
                image.sprite = Sprite.Create(Tex, rect, new Vector2(0.0f, 0.0f));

                Accessortest.text = timedata.ToString();
    
            }
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            var heartState = MemoryMappedFile.OpenExisting("SM_HR_DATA");
            var respirState = MemoryMappedFile.OpenExisting("SM_RR_DATA");
            var faceState = MemoryMappedFile.OpenExisting("SM_FACESTATE_DATA");
            //var faceTime = MemoryMappedFile.OpenExisting("SM_FACESTATE_TIME");

            var accessorHeart = heartState.CreateViewAccessor();
            double hr = accessorHeart.ReadDouble(0);
            hrText.text = "Heart Rate: " + hr.ToString();

            var accessorRespir = respirState.CreateViewAccessor();
            double rr = accessorRespir.ReadDouble(0);
            rrText.text = "Respiratory Rate: " + rr.ToString();

            var accessorFace = faceState.CreateViewAccessor();
            accessorFace.ReadArray(0, FaceData, 0, FaceData.Length);
            string faceTxt = System.Text.Encoding.UTF8.GetString(FaceData);
            faceText.text = "Face State: " + faceTxt;
            if (faceState != null)
            {

                //var bytes = new Byte[accessorFace.Capacity];
                //accessorFace.ReadArray<byte>(0, bytes, 0, bytes.Length);
                //accessorState.ReadArray(0, FaceData, 0, FaceData.Length);

                //Texture2D texure = new Texture2D(640, 480, TextureFormat.RGB24, false);
                //texure.LoadRawTextureData(FaceData);
                //texure.Apply();
                //Rect rect = new Rect(0, 0, 640, 480);
                //faceimage.sprite = Sprite.Create(texure, rect, new Vector2(0, 0));
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && keydown == true)
        {
            keydown = false;
            Space.text = keydown.ToString();
        }
    }
}
