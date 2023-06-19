using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

[RequireComponent(typeof(Button))]
public class FileControl : MonoBehaviour, IPointerDownHandler {

    private byte[] _textureBytes;

    // Standalone platforms & editor
    public void OnPointerDown(PointerEventData eventData) { }

    void Start() {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick() {
        var paths = StandaloneFileBrowser.OpenFilePanel("Model", "", "3ds", false);
        if (paths.Length > 0) {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    private IEnumerator OutputRoutine(string url) {
        var loader = new WWW(url);
        var filenames = url.Split(new char[2] {'/', '.'});
        var filename = filenames[filenames.Length-2];
        var path = Application.dataPath + "/Vehicles/" + filename + ".3ds";
        yield return loader;
        byte[] _textureBytes = loader.texture.EncodeToPNG();
        File.WriteAllBytes(path, _textureBytes);
    }
}