using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Storage;
using System.IO;

public class FirebaseStorage : MonoBehaviour
{

    [SerializeField] List<string> allFilesInBucket = new List<string>();
    [SerializeField] private string destinationFilePath = Application.streamingAssetsPath;

    private Firebase.Storage.FirebaseStorage storageLocation;
    private StorageReference storageBucket;
    private string storgeBucketURL = "gs://taxcorp-c327b.appspot.com";

    [SerializeField] bool simulateNoInternet;
    List<FileData> StorageBucketFileMetaData = new List<FileData>(); //Store metadata for each file in the bucket

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //If no internet
        if(Application.internetReachability == NetworkReachability.NotReachable || simulateNoInternet)
        {
            Debug.LogError("No Internet, throw message on screen");
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
            }
            else
            {
                Debug.Log("File Found " + fileData.Name);
            }
        }
        yield return null;
    }

    IEnumerator DownloadFiles()
    {
        yield return null;
    }

    private bool isFileUpToDate(FileInfo localFile, FileData metaData)
    {
        return true;
    }



    IEnumerator GetFileMetaData(StorageReference fileToCheck)
    {
        yield return null; 
    }

    IEnumerator DownloadFile(StorageReference fileToDownload)
    {
        yield return null; 
    }
}
