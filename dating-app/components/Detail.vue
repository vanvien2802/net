<template>
  <div v-if="user" class="card">
    <img class="card-img-top" :src="user.avatar" :alt="user.knownAs" />
    <div class="card-body">
      <h3 class="card-title">{{ user.knownAs }}</h3>
      <p class="card-text">{{ user.gender }} - {{ user.city }}</p>
      <a href="#" class="btn btn-primary">Detail</a>
    </div>
  </div>
</template>
<script lang="ts" setup>
import type { PropType } from "vue";
import type { User } from "../types";
defineProps({
  user: { type: Object as PropType<User>, required: true },
});
</script>
