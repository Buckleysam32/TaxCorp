using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Storage;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine.Networking;

public class FirebaseStorage : MonoBehaviour
{

    [SerializeField] List<string> allFilesInBucket = new List<string>();
    [SerializeField] private string destinationFolderPath = Application.streamingAssetsPath;

    private Firebase.Storage.FirebaseStorage storageLocation;
    private StorageReference storageBucket;
    private string storgeBucketURL = "gs://taxcorp-c327b.appspot.com";

    [SerializeField] bool simulateNoInternet;
    [SerializeField]List<FileData> StorageBucketFileMetaData = new List<FileData>(); //Store metadata for each file in the bucket

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //If no internet
        if(Application.internetReachability == NetworkReachability.NotReachable || simulateNoInternet)
        {
            Debug.LogError("No Internet, throw message on screen");
            yield break;
        }

        //Show an animated loading screen here

        GetFirebaseInstance();

        GetFirebaseStorageReference();

        //Check for bucket
        if(storageBucket != null)
        {
            //Grab all files in the bucket
            yield return StartCoroutine(GetAllFilesInBucket());
        }

        if(StorageBucketFileMetaData.Count > 0)
        {
            yield return StartCoroutine(DownloadFiles());
        }

        //Hide loading screen and continue

        yield return null; 
    }
    
    void GetFirebaseInstance()
    {
        storageLocation = Firebase.Storage.FirebaseStorage.DefaultInstance;

        if(storageLocation == null)
        {
            Debug.Log("Storage Location Not Found");
        }
    }

    void GetFirebaseStorageReference()
    {
        if(storageLocation == null)
        {
            return;
        }

        storageBucket = storageLocation.GetReferenceFromUrl(storgeBucketURL);

        if (storageBucket == null)
        {
            Debug.Log("Storage Bucket Not Found");
        }
    }

    IEnumerator GetAllFilesInBucket()
    {
        for(int i  = 0; i<allFilesInBucket.Count; i++)
        {
            StorageReference fileData = storageBucket.Child(allFilesInBucket[i]);

            if (fileData == null)
            {
                Debug.Log("File Not Found");
                continue;
            }
            else
            {
                Debug.Log("File Found " + fileData.Name);

                yield return StartCoroutine(GetFileMetaData(fileData));
            }
        }
        yield return null;
    }
    IEnumerator GetFileMetaData(StorageReference fileToCheck)
    {

        Task<StorageMetadata> fileToCheckMetaData = fileToCheck.GetMetadataAsync();

        while(fileToCheckMetaData != null && !fileToCheckMetaData.IsCompleted)
        {
            Debug.Log("Getting File meta data " + fileToCheck.Name);
            yield return null;
        }

        StorageMetadata metaData = fileToCheckMetaData.Result;

        if(metaData != null)
        {
            FileData newFile = new FileData();

            newFile.fileName = metaData.Name;
            newFile.dateCreated = metaData.CreationTimeMillis;
            newFile.dateLastModified = metaData.UpdatedTimeMillis;
            newFile.dateCreatedString = metaData.CreationTimeMillis.ToUniversalTime().ToString();
            newFile.dateModifiedString = metaData.UpdatedTimeMillis.ToUniversalTime().ToString();
            newFile.fileSize = metaData.SizeBytes;
            newFile.fileDestination = Path.Combine(destinationFolderPath, metaData.Name);

            StorageBucketFileMetaData.Add(newFile);
        }

        yield return null;
    }

    IEnumerator DownloadFiles()
    {
        for(int i = 0; i< StorageBucketFileMetaData.Count; i++)
        {
            //Check if there is already a local file
            bool fileExists = File.Exists(StorageBucketFileMetaData[i].fileDestination);

            if (fileExists)
            {
                //Check if file is up to date
                //If not, delete local file
                //If it is, do nothing
            }

            if (!fileExists)
            {
                //Download the file
                yield return DownloadFile(storageBucket.Child(StorageBucketFileMetaData[i].fileName));
            }

            yield return null;

        }

        yield return null;
    }

    private bool isFileUpToDate(FileInfo localFile, FileData metaData)
    {
        return true;
    }

    IEnumerator DownloadFile(StorageReference fileToDownload)
    {
        Task<Uri> uri = fileToDownload.GetDownloadUrlAsync();

        while (!uri.IsCompleted)
        {
            Debug.Log("Getting URI Data " + fileToDownload.Name);

            yield return null;
        }

        //We have information now on where file is located

        UnityWebRequest www = new UnityWebRequest(uri.Result);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Request Successful");

            byte[] resultData = www.downloadHandler.data;

            //Could update UI here (like a downloading progress bar)
            while(www.downloadProgress < 1)
            {
                Debug.Log("Downloading " + fileToDownload.Name + (www.downloadProgress * 100) + "%");
                yield return null;
            }

            string destinationPath = Path.Combine(destinationFolderPath, fileToDownload.Name);

            Task writeFile = File.WriteAllBytesAsync(destinationPath, resultData);

            while (!writeFile.IsCompleted)
            {
                Debug.Log("Writing file data please wait " + fileToDownload.Name);
                yield return null;
            }

            Debug.Log("Download Completed");
        }

        yield return null; 
    }
}
