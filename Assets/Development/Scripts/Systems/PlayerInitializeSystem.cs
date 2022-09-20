using Leopotam.Ecs;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    // Main
    private EcsWorld ecsWorld;

    // Data
    private SceneData sceneData;
    //private StaticData staticData;
    //private UI ui;
    //private RuntimeData runtimeData;

    public void Init()
    {
        // Install player
        EcsEntity playerEntity = ecsWorld.NewEntity();
            ref var moveComponent = ref playerEntity.Get<MoveComponent>();
            ref var inputComponent = ref playerEntity.Get<InputComponent>(); 
            ref var playerComponent = ref playerEntity.Get<PlayerComponent>();

            // Fill move data
            moveComponent.Transform = sceneData.PlayerTransform;
            moveComponent.Animator = sceneData.PlayerTransform.GetComponentInChildren<Animator>();
            moveComponent.MoveSpeed = 3.2f;
            moveComponent.RotateSpeed = 6.4f;
            moveComponent.CharacterController = sceneData.PlayerTransform.GetComponent<CharacterController>();
        /*

        ref var inputData = ref playerEntity.Get<PlayerInputData>(); 
        ref var hasWeapon = ref playerEntity.Get<HasWeapon>();
        ref var animatorRef = ref playerEntity.Get<AnimatorRef>();
        ref var health = ref playerEntity.Get<Health>();
        ref var transformRef = ref playerEntity.Get<TransformRef>();
        
        GameObject playerGO = Object.Instantiate(staticData.playerPrefab, sceneData.playerSpawnPoint.position,
            Quaternion.identity);
        player.playerTransform = playerGO.transform;
        player.playerAnimator = playerGO.GetComponent<Animator>();
        player.playerRigidbody = playerGO.GetComponent<Rigidbody>();
        player.playerSpeed = staticData.playerSpeed;

        var weaponEntity = ecsWorld.NewEntity();
        var weaponView = playerGO.GetComponentInChildren<WeaponSettings>();
        ref var weapon = ref weaponEntity.Get<Weapon>();
        weapon.owner = playerEntity;
        weapon.projectilePrefab = weaponView.projectilePrefab;
        weapon.projectileRadius = weaponView.projectileRadius;
        weapon.projectileSocket = weaponView.projectileSocket;
        weapon.projectileSpeed = weaponView.projectileSpeed;
        weapon.totalAmmo = weaponView.totalAmmo;
        weapon.weaponDamage = weaponView.weaponDamage;
        weapon.currentInMagazine = weaponView.currentInMagazine;
        weapon.maxInMagazine = weaponView.maxInMagazine;

        health.value = staticData.playerHealth;

        transformRef.transform = playerGO.transform;
        runtimeData.playerEntity = playerEntity;

        ui.gameScreen.SetAmmo(weapon.currentInMagazine, weapon.totalAmmo);

        hasWeapon.weapon = weaponEntity;

        playerGO.GetComponent<PlayerView>().entity = playerEntity;

        animatorRef.animator = player.playerAnimator;
        */
    }
}