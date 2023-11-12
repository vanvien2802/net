<template>
    <div class="container">
        <Navbar/>
        <div class="row" v-if="users">
            <div class="col-3 p-2" v-for="(user, index) in users" :key="index">
                <Detail :user="user" />
            </div>
        </div>
    </div>
</template>
<script lang="ts" setup>
import type { User } from "../types";
const { data: users } =
    await useFetch<User[]>("http://localhost:5216/api/users");
</script>
