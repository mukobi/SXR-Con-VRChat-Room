using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class WearableHat : UdonSharpBehaviour
{
    public int maxPlayers = 20;
    public Transform tracker;
    private Transform cachedParent;

    private VRCPlayerApi mountedPlayer = null;
    private float maxMountDist = 1f;

    private void Start()
    {
        cachedParent = gameObject.transform.parent;
    }

    private void Update()
    {
        AlignTracker();
    }

    public override void OnPickup()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "UnmountHat");
    }
    public override void OnPickupUseDown()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "AttachHatToHead");

        // Drop the pickup
        ((VRC_Pickup)GetComponent(typeof(VRC_Pickup))).Drop();
    }

    public void AttachHatToHead()
    {
        // Check for the nearest player to attach to and set offset
        var players = new VRCPlayerApi[maxPlayers];
        players = VRCPlayerApi.GetPlayers(players);
        mountedPlayer = null;
        float minMountDist = float.PositiveInfinity;
        foreach (var player in players)
        {
            if (player != null)
            {
                // Check that the head is within range of the hat
                var trackingData = player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
                var dist = gameObject.transform.position - trackingData.position;
                if (dist.magnitude <= maxMountDist && dist.magnitude < minMountDist)
                {
                    mountedPlayer = player;
                    minMountDist = dist.magnitude;
                }
            }
        }

        if (mountedPlayer != null)
        {
            // Change ownership to the hat wearer
            if (Networking.IsOwner(gameObject))
            {
                Networking.SetOwner(mountedPlayer, gameObject);
            }
            MountHat();
        }
    }
    
    private void AlignTracker()
    {
        if (mountedPlayer == null) return;

        var trackingData = mountedPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
        tracker.SetPositionAndRotation(trackingData.position, trackingData.rotation);
    }

    private void MountHat()
    {
        AlignTracker();
        gameObject.transform.SetParent(tracker);
    }
    public void UnmountHat()
    {
        mountedPlayer = null;
        gameObject.transform.SetParent(cachedParent);
    }
}
