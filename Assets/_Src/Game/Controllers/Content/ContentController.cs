using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Interfaces.Game;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SubNet.Game.Controllers.Content
{


    public class ContentController : EmberSingleton, IContentController
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public void LoadContentFromResources<SO, C>(object key, ContentFactory<SO, C> factoryMethod, Action<List<C>> callback)
        {
            List<C> assets = new List<C>();
            AsyncOperationHandle<IList<SO>> handle = Addressables.LoadAssetsAsync<SO>(key, null);

            handle.Completed += (obj) =>
            {
                if (obj.Status == AsyncOperationStatus.Succeeded)
                {
                    IList<SO> contentSOs = obj.Result;
                    //Debug.Log("ContentSOs Count: " + contentSOs.Count);
                    foreach (SO contentSO in contentSOs)
                    {
                        // Use the factory method to create instances of C
                        C contentItem = factoryMethod(contentSO);
                        assets.Add(contentItem);
                    }
                    // Once done with the assets, release them
                    Addressables.Release(handle);

                    // Invoke the callback with the loaded assets
                    callback?.Invoke(assets);
                }
                else
                {
                    Debug.LogError("Failed to load content assets.");
                }
            };
        }

    }
}
