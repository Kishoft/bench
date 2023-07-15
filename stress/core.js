
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '1s', target: 500 },
  ],
};

export default function () {
  const res =  http.get('http://192.168.1.38:5000/user');
  check(res, { 'status was 200': (r) => r.status == 200 });
  sleep(1);
}